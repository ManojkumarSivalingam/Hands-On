using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HCS.OneTap.Model.Entities
{
     [DataContract]
  public class Category
    {
         private int _Category_Id;
         private string _Category_name;
         private List<CategoryKeyword> _keywords;
         [DataMember]
         public int CategoryId
         {
             get { return _Category_Id; }
             set { _Category_Id = value; }
         }
         [DataMember]
         public string CategoryName
         {
             get { return _Category_name; }
             set { _Category_name = value; }
         }

         [DataMember]
         public List<CategoryKeyword> Keywords
         {
             get { return _keywords; }
             set { _keywords = value; }
         }
         [DataMember]
         public string KeywordList
         {
             get
             {
                 if (Keywords != null && Keywords.Count > 0)
                 {
                     string[] array = new string[Keywords.Count];
                     for (int i = 0; i < Keywords.Count; i++)
                     {
                         array[i] = Keywords[i].text;
                     }

                     return String.Join(",", array);
                 }
                 return "";
             }
             set {
                 var text = value;
                 if (text.Length > 0)
                 {
                     var arr = text.Split(',');
                     Keywords = new List<CategoryKeyword>();
                     foreach (var item in arr)
                     {
                         Keywords.Add(new CategoryKeyword { text = item });
                     }
                 }
                 else
                     Keywords = new List<CategoryKeyword>();
             }
         }
        
    }
    [DataContract]
     public class CategoryKeyword
     {
        [DataMember]
         public string text { get; set; }
     }
}
