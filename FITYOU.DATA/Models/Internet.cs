using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Internet
    {
        public Internet()
        {
            DetailPlans = new HashSet<DetailPlan>();
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        public int Uploadspeed { get; set; }
        public int Loweringspeed { get; set; }
        public int Speed { get; set; }
        public string TypeOfNet { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<DetailPlan> DetailPlans { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
