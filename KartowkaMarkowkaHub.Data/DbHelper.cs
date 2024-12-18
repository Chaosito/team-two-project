﻿using KartowkaMarkowkaHub.Core.Domain;
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

            context.Database.Migrate();
            //if (context.Database.EnsureCreated())
            //{
            //    //context.Database.Migrate();
            //}
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
            var guidRoleAdmin = new Guid("f62087f8-c4f5-4106-a4c0-6cb9a311e31d");
            var guidRoleModer = new Guid("a0a88ca9-9e3e-4564-b152-006722093ebf");

            context.Set<Role>().AddRange(new Role() { Id = guidRoleAdmin, Name = "admin", Description = "Администратор" });
            context.Set<Role>().AddRange(new Role() { Id = guidRoleModer, Name = "moder", Description = "Модератор" });

            var guidUser = new Guid("6EBC929B-3785-49D9-9D46-B3B9F70B0BB5");
            context.Set<User>().AddRange(new User() { Id = guidUser, Login = "Wower", Email = "wower@mail.ru", Password = "123123", Roles = new List<UserRole>() { new UserRole() { RoleId = guidRoleAdmin, UserId = guidUser } } });

            context.Set<Product>().AddRange([
                new() { Name = "Картошка", Price = 150, UserId = guidUser, User = new() },
                new() { Name = "Морковка", Price = 120, UserId = guidUser, User = new() },
                new() { Name = "Помидорки", Price = 300, UserId = guidUser, User = new() },
                new() { Name = "Лук", Price = 175, UserId = guidUser, User = new() },
                new() { Name = "Чеснок", Price = 900, UserId = guidUser, User = new() },
                new() { Name = "Молоко", Price = 500, UserId = guidUser, User = new() },
                new() { Name = "Яблоки", Price = 250, UserId = guidUser, User = new() },
                new() { Name = "Вишня", Price = 500, UserId = guidUser, User = new() },
                new() { Name = "Творог", Price = 1700, UserId = guidUser, User = new() },
                new() { Name = "Мёд", Price = 7000, UserId = guidUser, User = new() },
            ]);

            context.Set<OrderStatus>().AddRange([
                new() { Name = "Создан", StatusType = StatusType.Created },
                new() { Name = "В работе", StatusType = StatusType.InProcess },
                new() { Name = "Готов к получению", StatusType = StatusType.ReadyToReceive },
                new() { Name = "Выполнен", StatusType = StatusType.Completed },
                new() { Name = "Отменён", StatusType = StatusType.Canceled },
            ]);


            context.SaveChanges();
        }
    }
}
