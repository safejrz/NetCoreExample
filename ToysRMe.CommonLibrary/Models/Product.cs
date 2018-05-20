using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ToysRMe.CommonLibrary.Models
{
  [DataContract]
  public class Product
  {
    [DataMember]
    [Required]
    public int Id { get; set; }

    [DataMember]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [DataMember]
    [MaxLength(100)]
    public string Description { get; set; }

    [DataMember]
    [Range(0, 100)]
    public int? AgeRestriction { get; set; }

    [DataMember]
    [Required]
    [MaxLength(50)]
    public string Company { get; set; }

    [DataMember]
    [Required]
    [Range(1, 1000)]
    public decimal Price { get; set; }
  }
}
