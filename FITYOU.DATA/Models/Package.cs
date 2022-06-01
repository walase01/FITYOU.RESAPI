using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Package
    {
        public Package()
        {
            TelecablePackages = new HashSet<TelecablePackage>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Chanels { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<TelecablePackage> TelecablePackages { get; set; }
    }
}
