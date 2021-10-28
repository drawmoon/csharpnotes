using System.Runtime.Serialization;

namespace RestApiJsonPatch.Models
{
    [DataContract]
    public class OrderDetail
    {
        [DataMember(Name = nameof(Name))]
        public string Name { get; set; }
    }
}
