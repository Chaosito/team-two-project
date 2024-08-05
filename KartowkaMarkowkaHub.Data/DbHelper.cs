using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Data
{
    public static class DbHelper
    {
        public static void Initialize(HubContext context)
        {
            if (DbConfiguration.ReCreateEveryRun)
            {
                ReCreatingDB(context);
            }

            if (DbConfiguration.FakeDataSeed)
            {
                FakeDataSeed(context);
            }
        }

        private static void ReCreatingDB(HubContext context)
        {
            context.Database.EnsureDeleted();
            if(DbConfiguration.CurrentDbType == DbType.SqlLite) DeleteSqlLiteFiles();

            if (context.Database.EnsureCreated())
            {
                context.Database.Migrate();
            }
        }

        private static void DeleteSqlLiteFiles()
        {
            var databaseFilePath = DbConfiguration.DbName;
            var walFilePath = $"{databaseFilePath}-wal";
            var shmFilePath = $"{databaseFilePath}-shm";

            // Удаляем файл базы данных, если он существует
            if (File.Exists(databaseFilePath))
            {
                File.Delete(databaseFilePath);
            }

            if (File.Exists(walFilePath))
            {
                File.Delete(walFilePath);
            }

            if (File.Exists(shmFilePath))
            {
                File.Delete(shmFilePath);
            }
        }

        private static void FakeDataSeed(HubContext context)
        {
            //context.Roles.AddRange(FakeDataFactory.GetData<Role>());
            //context.Employees.AddRange(FakeDataFactory.GetData<Employee>());
            //context.Preferences.AddRange(FakeDataFactory.GetData<Preference>());
            //context.Customers.AddRange(FakeDataFactory.GetData<Customer>());
            //context.SaveChanges();
        }
    }
}
