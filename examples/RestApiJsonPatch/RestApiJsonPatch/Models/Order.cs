using System.Runtime.Serialization;

namespace RestApiJsonPatch.Models
{
    [DataContract]
    public class Order
    {
        [DataMember(Name = nameof(Name))]
        public string Name { get; set; }

        [DataMember(Name = nameof(OrderDetails))]
        public OrderDetail[] OrderDetails { get; set; }
    }
}
