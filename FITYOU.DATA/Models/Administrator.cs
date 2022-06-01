using System;
using System.Collections.Generic;

namespace FITYOU.DATA.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Email { get; set; }
        public string TypeOfUser { get; set; } = null!;
        public DateTime RegisterUser { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}
