using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.Web.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aditi.Libraries.Web.Models.Providers
{
    public class AditiModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected override ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            var typeDescriptor = base.GetTypeDescriptor( type );

            if ( type == typeof( Customer ) )
                return new AssociatedMetadataTypeTypeDescriptionProvider(
                    type, typeof( CustomerMetadata ) ).GetTypeDescriptor( type );

            return typeDescriptor;
        }
    }
}
