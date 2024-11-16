namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketDto
    {
        public Guid UserId { get; set; }    

        public IEnumerable<Guid> ProductIdList { get; set; } = [];
    }
}
