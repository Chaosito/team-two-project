namespace KartowkaMarkowkaHub.Services.Account
{
    public class UserException : BaseServiceException
    {
        // Пустой конструктор
        public UserException() : base() { }

        // Конструктор, который принимает сообщение
        public UserException(string message) : base(message) { }

        // Конструктор, который принимает сообщение и внутреннее исключение
        public UserException(string message, Exception innerException) : base(message, innerException) { }

        // Конструктор, который принимает сообщение, внутреннее исключение и код ошибки
        public UserException(string message, Exception innerException, int errorCode) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
