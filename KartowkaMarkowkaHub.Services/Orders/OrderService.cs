using AutoMapper;
using FluentValidation;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.OrderStatuses;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;

        public OrderService(
            IUnitOfWork unitOfWork,
            IValidator validator, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
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

        public void Create(CreateOrderDto productDto, Guid userId)
        {
            var validationContext = new ValidationContext<CreateOrderDto>(productDto);
            var errors = _validator.Validate(validationContext).Errors;
            if (errors.Count != 0)
                throw new ValidationException(errors);

            Order order = _mapper.Map<Order>(productDto);
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

            var validationContext = new ValidationContext<UpdateOrderDto>(orderDto);
            var errors = _validator.Validate(validationContext).Errors;
            if (errors.Count != 0)
                throw new ValidationException(errors);

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