using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class DetailPlan
    {
        public DetailPlan()
        {
            CompanyDetails = new HashSet<CompanyDetail>();
        }

        public int Id { get; set; }
        public int InternetId { get; set; }
        public int TelecableId { get; set; }
        public int TelephoneId { get; set; }

        public virtual Internet Internet { get; set; } = null!;
        public virtual Telecable Telecable { get; set; } = null!;
        public virtual Telephone Telephone { get; set; } = null!;
        public virtual ICollection<CompanyDetail> CompanyDetails { get; set; }
    }
}
