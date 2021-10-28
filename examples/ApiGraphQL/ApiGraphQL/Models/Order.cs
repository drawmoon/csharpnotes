using System.Collections.Generic;

namespace ApiGraphQL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
