namespace KartowkaMarkowkaHub.Application.Abstractions.Common.Models
{
    public class Response<TResult> : IExceptionResponce
    {
        public TResult Result { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
