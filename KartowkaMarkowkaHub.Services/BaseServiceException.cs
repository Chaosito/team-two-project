using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services
{
    public class BaseServiceException : Exception
    {
        // Пустой конструктор
        public BaseServiceException() : base() { }

        // Конструктор, который принимает сообщение
        public BaseServiceException(string message) : base(message) { }

        // Конструктор, который принимает сообщение и внутреннее исключение
        public BaseServiceException(string message, Exception innerException) : base(message, innerException) { }

        // Опционально: добавление собственного свойства
        public int ErrorCode { get; set; }

        // Конструктор, который принимает сообщение, внутреннее исключение и код ошибки
        public BaseServiceException(string message, Exception innerException, int errorCode) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
