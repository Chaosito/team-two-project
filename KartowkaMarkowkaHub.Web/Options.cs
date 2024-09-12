namespace KartowkaMarkowkaHub.Web
{
    public class Options
    {
        public ConnectionStrings ConnectionStrings { get; set; } = null!;
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; } = string.Empty;
        public string PostgresConnection { get; set; } = string.Empty;
        public string RedisConnection { get; set; } = string.Empty;
    }
}