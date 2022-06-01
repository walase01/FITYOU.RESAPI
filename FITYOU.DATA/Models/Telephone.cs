using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Telephone
    {
        public Telephone()
        {
            DetailPlans = new HashSet<DetailPlan>();
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        public string Minutes { get; set; } = null!;
        public string Service { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<DetailPlan> DetailPlans { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
