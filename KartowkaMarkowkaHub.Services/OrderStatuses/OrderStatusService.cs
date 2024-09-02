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
            _orderStatus = GetStatus(orderId);
            _order = unitOfWork.OrderRepository.GetByID(orderId);
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

        private void SaveStatusInOrder()
        {
            //Status.StatusType;
            //_order.OrderStatusId = ;
            //_unitOfWork.OrderRepository.Update(_order);
            //_unitOfWork.Save();
        }

        public void SetNextStatus()
        {
            _orderStatus.NextStatus(this);
            SaveStatusInOrder();
        }

        public string GetStatusName()
        {
            return _order.OrderStatus.Name;
        }
    }
}