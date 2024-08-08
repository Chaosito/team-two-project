using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public static class DbConfiguration
    {
        /// <summary>
        /// Определяет имя БД
        /// </summary>
        public static string DbName => "HubDatabase.db";

        /// <summary>
        /// Определяет какой тип БД конструировать в Ef Core
        /// </summary>
        public static DbType CurrentDbType => DbType.SqlLite;

        /// <summary>
        /// Определяет пересоздавать ли БД при каждом запуске
        /// </summary>
        public static bool ReCreateEveryRun = true;

        /// <summary>
        /// Заполнить предварительными данными
        /// </summary>
        public static bool FakeDataSeed = true;
    }

    public enum DbType
    {
        /// <summary>
        /// SqlLite
        /// </summary>
        SqlLite = 0,

        /// <summary>
        /// InMemory
        /// </summary>
        InMemory = 1,

        /// <summary>
        /// PostgreSQL
        /// </summary>
        PostgreSql = 2
    }
}
