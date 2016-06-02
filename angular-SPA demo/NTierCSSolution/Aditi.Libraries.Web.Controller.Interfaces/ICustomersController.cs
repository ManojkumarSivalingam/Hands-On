using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aditi.Libraries.Web.Controller.Interfaces
{
    public interface ICustomersController
    {
        ActionResult GetIndexContents();
        ActionResult GetSearchCustomerResults(string searchString);
        ActionResult GetCustomerDetails(int customerId);
        ActionResult InitializeNewForm();
        ActionResult SaveCustomerForm(Customer customer);
    }
}
