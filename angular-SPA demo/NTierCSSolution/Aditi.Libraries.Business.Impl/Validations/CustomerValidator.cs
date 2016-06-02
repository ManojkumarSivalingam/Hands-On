using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aditi.Libraries.Business.Impl.Validations
{
    public class CustomerValidator : ICustomerValidator
    {
        private const int MIN_CREDIT_LIMIT = 1;
        private const int MAX_CREDIT_LIMIT = 10000;
        private const int MAX_NAME_LENGTH = 25;
        private const string EMAIL_PATTERN = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private const string PHONE_PATTERN = @"^\d{3,5}-\d{6,8}$";

        private static string[] badWords = new string[] { "bad", "worse", "not good", "evil" };

        #region ICustomerValidator Members

        public bool Validate(Customer customer)
        {
            var validation = customer != default( Customer ) &&
                Validate( customer.CustomerName ) &&
                customer.CustomerName.Length <= MAX_NAME_LENGTH &&
                customer.CreditLimit >= MIN_CREDIT_LIMIT &&
                customer.CreditLimit <= MAX_CREDIT_LIMIT &&
                Regex.Match( customer.EmailId, EMAIL_PATTERN ).Success &&
                Regex.Match( customer.PhoneNumber, PHONE_PATTERN ).Success;

            return validation;
        }

        public bool Validate(string customerName)
        {
            return !string.IsNullOrEmpty( customerName ) && !badWords.Contains( customerName );
        }

        #endregion
    }
}
