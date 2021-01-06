using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EcommMVC.Models
{
  public class Order
  {
    [Key]
    [Required]
    [StringLength(128)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderId { get; set; }
    public string UserId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Address1 { get; set; }
    [Required]
    public string Address2 { get; set; }
    [Required]
    public int ZipCode { get; set; }
    [Required]
    public bool SaveInfo { get; set; }

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }

    public Order()
    {

    }

    public override bool Equals(object obj)
    {
      return obj is Order order &&
             OrderId == order.OrderId &&
             UserId == order.UserId &&
             FirstName == order.FirstName &&
             LastName == order.LastName &&
             Email == order.Email &&
             Address1 == order.Address1 &&
             Address2 == order.Address2 &&
             ZipCode == order.ZipCode &&
             SaveInfo == order.SaveInfo &&
             EqualityComparer<ApplicationUser>.Default.Equals(User, order.User);
    }

    public override int GetHashCode()
    {
      int hashCode = 1069919772;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderId);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address1);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address2);
      hashCode = hashCode * -1521134295 + ZipCode.GetHashCode();
      hashCode = hashCode * -1521134295 + SaveInfo.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<ApplicationUser>.Default.GetHashCode(User);
      return hashCode;
    }
  }
}