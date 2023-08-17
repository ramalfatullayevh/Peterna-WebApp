using Peterna.Models.Base;

namespace Peterna.ViewModels
{
    public class UpdateServiceVM:BaseNameableEntity
    {
        public string IconUrl { get; set; }
        public string PrimaryDescription { get; set; }
        public string SecondaryDescription { get; set; }
    }
}
