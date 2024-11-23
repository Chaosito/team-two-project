using KartowkaMarkowkaHub.Basket.ViewModels;

namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    }
}
