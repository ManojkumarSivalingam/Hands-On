using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HCS.OneTap.Model
{
    [DataContract]
    public class News
    {
        [DataMember]
        public int NewsId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double  Longitude { get; set; }
        [DataMember]
        public double Radius { get; set; }
    }
}
