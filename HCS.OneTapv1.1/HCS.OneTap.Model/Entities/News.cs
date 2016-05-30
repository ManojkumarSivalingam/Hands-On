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
    public class News
    {
        private int _newsId;
        private string _shortMessage;
        private string _message;
        private double _latitude;
        private double _longitude;
        private double _radius;
        private string _userName;
        private string _imageurl;
        private int? _NDSId;
        private int? _wlvcid;
        private int? _wlvid;


        [DataMember]
        public int? NDSId
        {
            get { return _NDSId; }
            set { _NDSId = value; }
        }

        [DataMember]
        
        public string Imageurl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public int NewsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        [DataMember]
        public string ShortMessage
        {
            get { return _shortMessage; }
            set { _shortMessage = value; }
        }

        [DataMember]
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        [DataMember]
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        [DataMember]
        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public double CreatedDate
        {
            get { return _createddate; }
            set { _createdate = value; }
        }

        [DataMember]
        public string Source { get; set; }

        public int? Wlvcid
        {
            get { return _wlvcid; }
            set { _wlvcid = value; }
        }
        public int? Wlvid
        {
            get { return _wlvid; }
            set { _wlvid = value; }
        }
        public string XML
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("<News>");
                if (this._NDSId != null)
                {
                    sb.AppendFormat("<NDSId>{0}</NDSId>", this._NDSId);
                }
                else {
                    sb.AppendFormat("<WLVId>{0}</WLVId>", this._wlvid);
                    sb.AppendFormat("<WLVC_Id>{0}</WLVC_Id>", this._wlvcid);
                }
                sb.AppendFormat("<Message>{0}</Message>", WebUtility.HtmlEncode(this._message));
                sb.AppendFormat("<Latitude>{0}</Latitude>", this._latitude);
                sb.AppendFormat("<Longitude>{0}</Longitude>", this._longitude);
                sb.AppendFormat("<Radius>{0}</Radius>", this._radius);
                sb.AppendFormat("<UserName>{0}</UserName>", WebUtility.HtmlEncode(this._userName));
                sb.AppendFormat("<Imageurl>{0}</Imageurl>", WebUtility.UrlEncode(this._imageurl));
                sb.AppendFormat("<NewsId>{0}</NewsId>", this._newsId);
                sb.AppendFormat("<Source>{0}</Source>", this.Source);
                sb.AppendFormat("<createddate>{0}</createddate>", this._createddate);
                
                 

                sb.Append("</News>");
                return sb.ToString();
            }

        }


        public double _createddate { get; set; }

        public double _createdate { get; set; }
    }
}
