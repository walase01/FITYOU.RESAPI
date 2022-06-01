using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Telecable
    {
        public Telecable()
        {
            DetailPlans = new HashSet<DetailPlan>();
            Plans = new HashSet<Plan>();
            TelecablePackages = new HashSet<TelecablePackage>();
        }

        public int Id { get; set; }
        public string Chanels { get; set; } = null!;
        public string? TypeOfTelecable { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<DetailPlan> DetailPlans { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<TelecablePackage> TelecablePackages { get; set; }
    }
}
