using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Contracts.Services
{
    [ServiceContract(
        Namespace = NamespaceConstants.CONTRACTS )]
    public interface ICustomerService
    {
        [OperationContract]
        [FaultContract( typeof( ServiceError ) )]
        [WebGet(
            UriTemplate = CustomersRestTemplates.ALL,
            ResponseFormat = WebMessageFormat.Json )]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        [FaultContract( typeof( ServiceError ) )]
        [WebGet(
            UriTemplate = CustomersRestTemplates.SEARCH,
            ResponseFormat = WebMessageFormat.Json )]
        IEnumerable<Customer> GetCustomers(string customerName);

        [OperationContract]
        [WebGet(
            UriTemplate = CustomersRestTemplates.DETAILS,
            ResponseFormat = WebMessageFormat.Json )]
        [FaultContract( typeof( ServiceError ) )]
        Customer GetCustomerDetails(int customerId);

        [OperationContract]
        [WebInvoke(
            UriTemplate = CustomersRestTemplates.SAVE,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json )]
        [FaultContract( typeof( ServiceError ) )]
        bool SaveCustomer(Customer customer);
    }
}
