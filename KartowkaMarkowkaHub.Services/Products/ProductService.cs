using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;
using AutoMapper;

namespace KartowkaMarkowkaHub.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        { 
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductViewModel> Get(Guid userId)
        {
            var products = _unitOfWork.ProductRepository
                .Get(filter: p => p.UserId == userId);
            var viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(products).ToList();
            return viewModels;
        }

        public IEnumerable<ProductViewModel> Get()
        {
            var products = _unitOfWork.ProductRepository.Get();
            var viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(products).ToList();
            return viewModels;
        }

        public void Create(ProductDto productDto, Guid userId)
        {
            Product product = _mapper.Map<Product>(productDto);
            product.UserId = userId;
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();            
        }        

        public void Update(Guid productId, ProductDto productDto)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productId) ?? throw new ArgumentNullException("Товар не найден в базе данных!");
            product = _mapper.Map(productDto, product);
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