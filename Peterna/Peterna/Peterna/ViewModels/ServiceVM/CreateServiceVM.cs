using Peterna.Models.Base;

namespace Peterna.ViewModels
{
    public class CreateServiceVM:BaseNameableEntity
    {
        public string IconUrl { get; set; }
        public string PrimaryDescription { get; set; }
        public string SecondaryDescription { get; set; }
    }
}
