using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Contracts.Services
{
    public static class CustomersRestTemplates
    {
        public const string SEARCH = "search/{customerName}";
        public const string ALL = "all";
        public const string DETAILS = "details?id={customerId}";
        public const string SAVE = "save";
    }
}
