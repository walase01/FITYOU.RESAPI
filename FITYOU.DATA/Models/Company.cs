using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyDetails = new HashSet<CompanyDetail>();
            Offices = new HashSet<Office>();
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CompanyDetail> CompanyDetails { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
