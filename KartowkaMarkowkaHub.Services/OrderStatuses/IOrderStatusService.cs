namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public interface IOrderStatusService
    {
        IOrderStatus Status { get; set; }
        void SetNextStatus();

        string GetStatusName();
    }
}
