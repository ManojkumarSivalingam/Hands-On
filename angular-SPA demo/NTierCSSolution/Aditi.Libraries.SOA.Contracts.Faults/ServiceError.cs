using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Contracts.Faults
{
    [DataContract(
        Namespace = NamespaceConstants.FAULTS )]
    public class ServiceError
    {
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public string Source { get; set; }

        public override string ToString()
        {
            return string.Format( @"{0}, {1}, {2}",
                this.ErrorId, this.ErrorMessage, this.Source );
        }
    }
}
