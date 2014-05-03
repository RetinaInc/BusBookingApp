using System.ComponentModel.DataAnnotations;

namespace Tripodea.BusDomain
{
    public class Company
    {
        public virtual int CompanyId { get; set; }
        
        [Required]
        public virtual string Name { get; set; }
    }
}
