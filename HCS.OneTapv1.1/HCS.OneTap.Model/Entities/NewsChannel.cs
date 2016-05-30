using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HCS.OneTap.Model
{
    [DataContract]
    public class NewsChannel
    {
      
        private string _newschannelname;
        private int _newsChannelId;
        [DataMember]
        public int NewsChannelId
        {
            get { return _newsChannelId; }
            set { _newsChannelId = value; }
        }
        [DataMember]
        public string NewsChannelName
        {
            get { return _newschannelname; }
            set { _newschannelname = value; }
        }

        [DataMember]
        public bool IsSelected { get; set; }
    }
}
