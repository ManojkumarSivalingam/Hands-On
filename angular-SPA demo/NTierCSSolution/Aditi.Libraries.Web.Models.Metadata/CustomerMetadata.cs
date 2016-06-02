using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Web.Models.Metadata
{
    public class CustomerMetadata
    {
        [Required(
            ErrorMessageResourceType = typeof( CustomerErrorResources ),
            ErrorMessageResourceName = "CustomerNameNull" )]
        [StringLength( 20 )]
        public string CustomerName { get; set; }

        [Required]
        public string Address { get; set; }

        [Range( 10000, 50000 )]
        public int CreditLimit { get; set; }

        [RegularExpression( @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" )]
        public string EmailId { get; set; }

        [RegularExpression( @"^\d{3,5}-\d{6,8}$" )]
        public string PhoneNumber { get; set; }
    }
}
