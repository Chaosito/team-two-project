using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data;
using Microsoft.EntityFrameworkCore;

namespace KartowkaMarkowkaHub.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly HubContext _db;

        public ProductService(HubContext db)
        { 
            _db = db;
        }

        public IEnumerable<ProductViewModel> GetAsync(Guid userId)
        {
            var products = _db.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

            return products;
        }

        public IEnumerable<ProductViewModel> GetAsync()
        {
            var products = _db.Products                
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

            return products;
        }

        public async Task<Guid> CreateAsync(ProductDto productDto)
        {       
            Product product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
            };
            Product model = (await _db.Products.AddAsync(product)).Entity;
            await _db.SaveChangesAsync();
            return model.Id;
        }        

        public void Update(Guid productId, ProductDto productDto)
        {
            var product = _db.Products.Find(productId) ?? throw new ArgumentNullException("Товар не найден в базе данных!");
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(Guid productId)
        {
            var product = _db.Products.Find(productId) ?? throw new ArgumentNullException("Товар не найден в базе данных!");
            _db.Remove(product);
            _db.SaveChanges();
        }
    }
}
