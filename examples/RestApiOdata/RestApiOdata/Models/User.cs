using System.Collections.Generic;

namespace RestApiOdata.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public bool LockoutEnabled { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
