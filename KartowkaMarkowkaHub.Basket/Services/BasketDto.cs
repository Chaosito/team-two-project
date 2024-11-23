namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketDto
    {
        public Guid UserId { get; set; }    

        public IList<Guid> ProductIdList { get; set; } = [];
    }
}
