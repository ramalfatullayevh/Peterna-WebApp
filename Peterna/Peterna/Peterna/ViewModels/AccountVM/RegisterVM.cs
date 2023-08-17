using Peterna.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Peterna.ViewModels
{
    public class RegisterVM:BaseEntity
    {
        [Required, MaxLength(15)]
        public string Name { get; set; }
        [Required, MaxLength(15)]
        public string Surname { get; set; }
        [Required, MaxLength(25)]
        public string UserName { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
