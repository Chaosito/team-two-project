using AutoMapper;
using FluentValidation;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.OrderStatuses;
using KartowkaMarkowkaHub.Services.Products;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator<CreateOrderDto>> _сreateOrderDtoValidators;
        private readonly IEnumerable<IValidator<UpdateOrderDto>> _updateOrderDtoValidators;

        public OrderService(
            IUnitOfWork unitOfWork, IMapper mapper, 
            IEnumerable<IValidator<UpdateOrderDto>> updateOrderDtoValidators, IEnumerable<IValidator<CreateOrderDto>> сreateOrderDtoValidators)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _updateOrderDtoValidators = updateOrderDtoValidators;
            _сreateOrderDtoValidators = сreateOrderDtoValidators;
        }

        public IEnumerable<GetOrderDto> Get(Guid clientId)
        { 
            var orders = _unitOfWork.OrderRepository
                .Get(filter: o => o.ClientId == clientId, includeProperties: typeof(Product).Name + "," + typeof(OrderStatus).Name);
            var viewModels = _mapper.Map<IEnumerable<GetOrderDto>>(orders).ToList();
            return viewModels;
        }

        public IEnumerable<GetOrderDto> Get()
        {
            var orders = _unitOfWork.OrderRepository.Get(includeProperties: typeof(Product).Name + "," + typeof(OrderStatus).Name);
            var viewModels = _mapper.Map<IEnumerable<GetOrderDto>>(orders).ToList();
            return viewModels;
        }

        public void Create(CreateOrderDto orderDto, Guid userId)
        {
            var context = new ValidationContext<CreateOrderDto>(orderDto);
            var failures = _сreateOrderDtoValidators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            Order order = _mapper.Map<Order>(orderDto);
            var firstStatus = _unitOfWork.OrderStatusRepository
                .Get(filter: x => x.StatusType == StatusType.Created)
                .First();

            order.OrderStatusId = firstStatus.Id;
            order.ClientId = userId;
            _unitOfWork.OrderRepository.Insert(order);
            _unitOfWork.Save();
        }                

        public void Update(Guid orderId, UpdateOrderDto orderDto)
        {
            Order order = _unitOfWork.OrderRepository.GetByID(orderId) 
                ?? throw new NullReferenceException("Order not found in database!");

            var context = new ValidationContext<UpdateOrderDto>(orderDto);
            var failures = _сreateOrderDtoValidators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            order.OrderStatusId = orderDto.OrderStatusId;
            order.ProductId = orderDto.ProductId;
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Save();
        }

        public void Remove(Guid orderId)
        {
            _unitOfWork.OrderRepository.Delete(orderId);
            _unitOfWork.Save();
        }

        public string GetStatusName(Guid orderId)
        {
            OrderStatusService orderStatusService = new(_unitOfWork, orderId);
            return orderStatusService.GetStatusName();
        }

        public void SetNextStatus(Guid orderId)
        {
            OrderStatusService orderStatusService = new(_unitOfWork, orderId);
            orderStatusService.SetNextStatus();
        }
    }
}