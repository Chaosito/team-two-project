using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Data.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly HubContext _db;
        private GenericRepository<Product>? _productRepository;

        public UnitOfWork(HubContext db)
        {
            _db = db;
        }

        public GenericRepository<Product> ProductRepository {
            get {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_db);
                return _productRepository;
            } 
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}