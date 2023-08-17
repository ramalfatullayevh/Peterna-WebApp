using Peterna.Models.Base;

namespace Peterna.Models
{
    public class Service:BaseNameableEntity
    {
        public string IconUrl { get; set; }
        public string PrimaryDescription { get; set; }
        public string SecondaryDescription { get; set; }
    }
}
