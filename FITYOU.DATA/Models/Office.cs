using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Office
    {
        public int Id { get; set; }
        public string Latitude { get; set; } = null!;
        public string Longitude { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
