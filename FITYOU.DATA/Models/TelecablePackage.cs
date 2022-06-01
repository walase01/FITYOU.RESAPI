using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class TelecablePackage
    {
        public int Id { get; set; }
        public int TelecableId { get; set; }
        public int PackageId { get; set; }

        public virtual Package Package { get; set; } = null!;
        public virtual Telecable Telecable { get; set; } = null!;
    }
}
