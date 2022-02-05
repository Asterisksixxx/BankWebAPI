using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BankWebAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
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
        //public List<Score> Scores { get; set; } = new List<Score>();
    }
}
