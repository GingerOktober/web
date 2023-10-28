using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace webnet.Models
{
    [Table("User")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Поле Имя не может быть пустым.")]
        public string Name { get; set; } = "";
        [EmailAddress(ErrorMessage = "Почта указана некорректно.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Пожалуйста, введите корректный email.")]

        [Required(ErrorMessage = "Поле Email не может быть пустым.")]
        public string Email { get; set; } = "";

        [RegularExpression(@"^[a-zA-Z0-9_.!#$@+-]+$", ErrorMessage = "Использованы недопустимые для пароля символы.")]
        [Required(ErrorMessage = "Поле Пароль не может быть пустым.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть не короче {2} символов.", MinimumLength = 6)]
        public string Password { get; set; } = "";
        [NotMapped]
        [RegularExpression(@"^[a-zA-Z0-9_.!#$@+-]+$", ErrorMessage = "Использованы недопустимые для пароля символы.")]
        [Required(ErrorMessage = "Поле Пароль не может быть пустым.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string? confirmPassword { get; set; } = "";

        public DateTime BirthDate { get; set; }
    }
}