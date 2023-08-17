using Peterna.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Peterna.ViewModels
{
    public class LoginVM:BaseEntity
    {
        [Required, MaxLength(25)]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
