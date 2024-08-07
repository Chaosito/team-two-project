using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Data.Data
{
    public class EfDbInitializer : IDbInitializer
    {
        private readonly HubContext _dataContext;

        public EfDbInitializer(HubContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void InitializeDb()
        {
            //_dataContext.Database.EnsureDeleted();
            //_dataContext.Database.EnsureCreated();

            //_dataContext.AddRange(FakeDataFactory.Employees);
            //_dataContext.SaveChanges();

            //_dataContext.AddRange(FakeDataFactory.Preferences);
            //_dataContext.SaveChanges();

            //_dataContext.AddRange(FakeDataFactory.Customers);
            //_dataContext.SaveChanges();

            //_dataContext.AddRange(FakeDataFactory.Partners);
            //_dataContext.SaveChanges();
        }
    }
}
