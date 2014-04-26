using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripodea.BusDomain
{
    public class Company
    {
        public virtual int CompanyId { get; set; }
        
        [Required]
        public virtual string Name { get; set; }
    }
}
