namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Client: User
    {
        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string Name { get; set; }

        public string Address { get; set; }

        // Навигационное свойство
        public ICollection<Order> Orders { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
