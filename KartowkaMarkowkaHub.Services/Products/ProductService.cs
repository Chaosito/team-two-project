using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;

namespace KartowkaMarkowkaHub.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductViewModel> Get(Guid userId)
        {
            var products = _unitOfWork.ProductRepository
                .Get(filter: p => p.UserId == userId)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

            return products;
        }

        public IEnumerable<ProductViewModel> Get()
        {
            var products = _unitOfWork.ProductRepository.Get()                
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

            return products;
        }

        public void Create(ProductDto productDto, Guid userId)
        {       
            Product product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                UserId = userId,
            };
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();            
        }        

        public void Update(Guid productId, ProductDto productDto)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productId) ?? throw new ArgumentNullException("Товар не найден в базе данных!");
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();
        }

        public void Remove(Guid productId)
        {
            _unitOfWork.ProductRepository.Delete(productId);
            _unitOfWork.Save();
        }
    }
}