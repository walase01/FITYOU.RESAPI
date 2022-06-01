using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class CompanyDetail
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int DetailPlanId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual DetailPlan DetailPlan { get; set; } = null!;
    }
}
