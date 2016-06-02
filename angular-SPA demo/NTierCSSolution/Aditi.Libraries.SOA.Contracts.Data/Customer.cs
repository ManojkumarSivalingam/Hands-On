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
    public class Customer : BaseEntity
    {
        private int customerId;
        private string customerName;
        private string address;
        private int creditLimit;
        private bool activeStatus;
        private string emailId;
        private string phoneNumber;
        private string remarks;

        #region Public Properties
        
        [DataMember]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; Notify(); }
        }

        [DataMember]
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; Notify(); }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; Notify(); }
        }

        [DataMember]
        public int CreditLimit
        {
            get { return creditLimit; }
            set { creditLimit = value; Notify(); }
        }

        [DataMember]
        public bool ActiveStatus
        {
            get { return activeStatus; }
            set { activeStatus = value; Notify(); }
        }

        [DataMember]
        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; Notify(); }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; Notify(); }
        }

        [DataMember]
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; Notify(); }
        } 

        #endregion

        public override string ToString()
        {
            return string.Format( @"{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                this.customerId, this.customerName, this.address,
                this.creditLimit, this.activeStatus, this.emailId, this.phoneNumber, this.remarks );
        }
    }
}
