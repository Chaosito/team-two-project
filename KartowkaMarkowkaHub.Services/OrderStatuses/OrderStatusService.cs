using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IOrderStatus _orderStatus;
        private Order _order;
        public IOrderStatus Status
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }

        public OrderStatusService(IUnitOfWork unitOfWork, Guid orderId)
        {
            _unitOfWork = unitOfWork;
            _order = unitOfWork.OrderRepository.Get(filter: x => x.Id == orderId, includeProperties: typeof(OrderStatus).Name).First();
            _orderStatus = GetStatus(orderId);            
        }

        public IOrderStatus GetStatus(Guid orderId)
        {
            IOrderStatus status = new StatusCreated();

            switch (_order.OrderStatus.StatusType)
            {
                case StatusType.Created:
                    status = new StatusCreated();
                    break;
                case StatusType.InProcess: 
                    status = new StatusInProcess(); 
                    break;
                case StatusType.ReadyToReceive: 
                    status = new StatusReadyToReceive();
                    break;
                case StatusType.Completed:
                    status = new StatusCompleted(); 
                    break;
                case StatusType.Canceled: 
                    status = new StatusCanceled(); 
                    break;
            }

            return status;
        }

        private void SaveStatusInOrder(StatusType oldStatusType)
        {
            if(oldStatusType == Status.StatusType) return;

            var orderStatus = _unitOfWork.OrderStatusRepository
                .Get(filter: s => s.StatusType == Status.StatusType)
                .FirstOrDefault();

            if (orderStatus == null)
            {
                return;
            }
            _order.OrderStatusId = orderStatus.Id;
            _unitOfWork.OrderRepository.Update(_order);
            _unitOfWork.Save();
        }

        public void SetNextStatus()
        {
            StatusType oldStatusType = Status.StatusType;
            _orderStatus.NextStatus(this);
            SaveStatusInOrder(oldStatusType);
        }

        public string GetStatusName()
        {
            return _order.OrderStatus.Name;
        }
    }
}