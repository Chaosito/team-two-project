using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class OrderService(IUnitOfWork unitOfWork, IMapper mapper) : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

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
    }
}