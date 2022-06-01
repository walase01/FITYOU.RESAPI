using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Plan
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string TypeOfPlan { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? ActiveTime { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = null!;
        public int AdministratorId { get; set; }
        public int CompanyId { get; set; }
        public int? InternetId { get; set; }
        public int? TelecableId { get; set; }
        public int? TelephoneId { get; set; }

        public virtual Administrator Administrator { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual Internet? Internet { get; set; }
        public virtual Telecable? Telecable { get; set; }
        public virtual Telephone? Telephone { get; set; }
    }
}
