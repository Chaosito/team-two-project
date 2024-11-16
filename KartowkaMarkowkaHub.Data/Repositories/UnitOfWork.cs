using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Data.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly HubContext _db;
        private GenericRepository<Product>? _productRepository;
        private GenericRepository<Order>? _orderRepository;
        private GenericRepository<OrderStatus>? _orderStatusRepository;

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

        public virtual GenericRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new GenericRepository<Order>(_db);
                return _orderRepository;
            }
        }

        public virtual GenericRepository<OrderStatus> OrderStatusRepository
        {
            get
            {
                if (_orderStatusRepository == null)
                    _orderStatusRepository = new GenericRepository<OrderStatus>(_db);
                return _orderStatusRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}