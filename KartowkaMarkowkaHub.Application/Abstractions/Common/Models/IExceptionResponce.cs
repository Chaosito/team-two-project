namespace KartowkaMarkowkaHub.Application.Abstractions.Common.Models
{
    public interface IExceptionResponce
    {
        bool HasError { get; set; }
        string Message { get; set; }
    }
}
