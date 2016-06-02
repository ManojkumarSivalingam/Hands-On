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
    public class ApplicationError : ApplicationException
    {
        private const string DEFAULT_APPLICATION_ERROR_MESSAGE = @"Application Error Occurred";
        public int ErrorId { get; set; }

        public ApplicationError() : base( DEFAULT_APPLICATION_ERROR_MESSAGE ) { }
        public ApplicationError(string message) : base( message ) { }
    }
}
