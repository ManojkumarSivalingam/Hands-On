
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HCS.OneTap.Model
{
    [DataContract]
    public class Logo
    {
        private int _wlvId;
        private string _whitelabelname;
        private string _logo;
        
        [DataMember]
        public int WLVID
        {
            get { return _wlvId ; }
            set { _wlvId = value; }
        }
        [DataMember]
        public string WhiteLabelName
        {
            get { return _whitelabelname; }
            set { _whitelabelname = value; }
        }
        [DataMember]
        public string WhiteLabelLogo
        {
            get { return _logo; }
            set { _logo = value; }
        }


    }
}
