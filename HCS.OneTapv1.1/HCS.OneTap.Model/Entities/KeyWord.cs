using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HCS.OneTap.Model.Entities
{
    [DataContract]
    public class KeyWord
    {
        private int _NDSId;
        private string _ndsName;
        private List<NewsChannel> _availableChannels;
        private int _wLVC_Id;
        private int _category_Id;
        private int _wLV_ID;
        private bool _isWLVC;
        private int _channelID;

        [DataMember]
        public string NDSName
        {
            get { return _ndsName; }
            set { _ndsName = value; }
        }
        [DataMember]
        public int NDSId
        {
            get { return _NDSId; }
            set { _NDSId = value; }
        }

        [DataMember]
        public List<NewsChannel> AvailableChannels
        {
            get { return _availableChannels; }
            set { _availableChannels = value; }
        }

        [DataMember]
        public int NewsChannelId
        {
            get { return _channelID; }
            set { _channelID = value; }
        }

        public string DelimitedChannelIds
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in _availableChannels)
                {
                    sb.AppendFormat("|{0}|", item.NewsChannelId.ToString());
                }
                return sb.ToString();
            }
            set
            {
                _availableChannels = new List<NewsChannel>();
                List<string> list = value.Split('|').ToList();
                foreach (var item in list)
                {
                    _availableChannels.Add(new NewsChannel { NewsChannelId = Convert.ToInt32(item) });
                }

            }
        }
         [DataMember]
        public int WLVC_Id
        {
            get { return _wLVC_Id ;}
            set { _wLVC_Id = value;}
        }
         [DataMember]
        public int WLV_ID
        {
            get { return _wLV_ID; }
            set { _wLV_ID = value; }
        }
         [DataMember]
        public int Category_Id
        {
            get { return _category_Id; }
            set { _category_Id = value; }
        }
         [DataMember]
        public bool IsWLVC
        {
            get { return _isWLVC; }
            set { _isWLVC = value; }
        }

    }
}
