using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Contracts.Data
{
    [DataContract(
        Namespace = NamespaceConstants.CONTRACTS )]
    public class Order
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string BillingAddress { get; set; }
        [DataMember]
        public int Units { get; set; }
        [DataMember]
        public int Amount { get; set; }

        public override string ToString()
        {
            return string.Format( @"{0}, {1}, {2}, {3}, {4}, {5}",
                this.OrderId, this.OrderDate.ToString(),
                this.CustomerId, this.BillingAddress, this.Units, this.Amount );
        }
    }
}
