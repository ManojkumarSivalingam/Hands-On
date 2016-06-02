using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Contracts.Data
{
    [DataContract(
        Namespace = NamespaceConstants.CONTRACTS )]
    public abstract class BaseEntity : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected virtual void Notify(
            [CallerMemberName] string propertyName = default(string))
        {
            if ( !string.IsNullOrEmpty( propertyName ) &&
                PropertyChanged != default( PropertyChangedEventHandler ) )
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
