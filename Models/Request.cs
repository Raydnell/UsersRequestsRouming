using System.ComponentModel.DataAnnotations;

namespace UsersRequestsRouming.Models;

public class Request : IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязательное поле")]
    [Display(Name = "Страна")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Обязательное поле")]
    [Display(Name = "Город")]
    public string City { get; set; }

    [Required(ErrorMessage = "Обязательное поле")]
    [Display(Name = "Регион")]
    public string Region { get; set; }

    [Required(ErrorMessage = "Обязательное поле")]
    [Display(Name = "Номер телефона")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Обязательное поле")]
    [Display(Name = "Причина обращения")]
    public string RequestReason { get; set; }

    [Required(ErrorMessage = "Обязательное поле")]
    [Display(Name = "Направление")]
    public string Direction { get; set; }

    public DateTime RequestDateTime { get; set; }

    public Request()
    {
        Country = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PhoneNumber = string.Empty;
        RequestReason = string.Empty;
        Direction = string.Empty;
    }
}
