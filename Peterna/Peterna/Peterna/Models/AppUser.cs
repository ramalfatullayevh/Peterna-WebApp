using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Peterna.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength (15)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
    }
}
