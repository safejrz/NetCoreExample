using System.Runtime.Serialization;

namespace ToysRMe.CommonLibrary.Models
{
  [DataContract]
  public class AppSettings
  {
    [DataMember]
    public string ToyRMeWebApiUrl { get; set; }
  }
}
