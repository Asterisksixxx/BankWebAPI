using System;
using System.ComponentModel.DataAnnotations;

namespace BankWebAPI.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Имя")]
        [RegularExpression(@"[\D]+", ErrorMessage = "Имя не может содержать цифр и спец. символов")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        [RegularExpression(@"[\D]+", ErrorMessage = "Фамилия не может содержать цифр и спец. символов")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Некорректная дата")]
        public DateTime DateBirth { get; set; }
        [Required]
        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Номер паспорта")]
        [RegularExpression(@"[А-ЯA-Z]{2}[0-9]{7}", ErrorMessage = "Формат номера должен быть AA0000000, 2 буквы и 7 цифр")]
        public string PassportNumber { get; set; }
    }
}
