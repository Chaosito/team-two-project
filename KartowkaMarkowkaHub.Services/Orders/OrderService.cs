using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.OrderStatuses;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<OrderViewModel> Get(Guid clientId)
        { 
            var orders = _unitOfWork.OrderRepository
                .Get(filter: o => o.ClientId == clientId, includeProperties: typeof(Product).Name + "," + typeof(OrderStatus).Name);
            var viewModels = _mapper.Map<IEnumerable<OrderViewModel>>(orders).ToList();
            return viewModels;
        }

        public IEnumerable<OrderViewModel> Get()
        {
            var orders = _unitOfWork.OrderRepository.Get(includeProperties: typeof(Product).Name + "," + typeof(OrderStatus).Name);
            var viewModels = _mapper.Map<IEnumerable<OrderViewModel>>(orders).ToList();
            return viewModels;
        }

        public void Create(OrderCreateRequest orderCreateRequest, Guid userId)
        {
            Order order = _mapper.Map<Order>(orderCreateRequest);

            order.ClientId = userId;
            _unitOfWork.OrderRepository.Insert(order);
            _unitOfWork.Save();
        }                

        public void Update(Guid orderId, OrderUpdateRequest orderUpdateRequest)
        {
            Order order = _unitOfWork.OrderRepository.GetByID(orderId) ?? throw new NullReferenceException("Order not found in database!");
            order.OrderStatusId = orderUpdateRequest.OrderStatusId;
            order.ProductId = orderUpdateRequest.ProductId;
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