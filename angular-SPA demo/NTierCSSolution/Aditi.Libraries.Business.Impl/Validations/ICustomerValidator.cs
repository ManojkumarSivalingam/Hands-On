using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Business.Impl.Validations
{
    public interface ICustomerValidator
    {
        bool Validate(Customer customer);
        bool Validate(string customerName);
    }
}
