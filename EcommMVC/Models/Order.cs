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
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OrderId { get; set; }
    public string UserId { get; set; }
    [Required]
    public string CCAddress { get; set; }
    public string CCName { get; set; }
    [Required]
    public int CCNumber { get; set; } 
    [Required] 
    public string CCExpiryDate { get; set; }
    
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
             CCAddress == order.CCAddress &&
             CCName == order.CCName &&
             CCNumber == order.CCNumber &&
             CCExpiryDate == order.CCExpiryDate;
    }

    public override int GetHashCode()
    {
      int hashCode = 536261816;
      hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CCAddress);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CCName);
      hashCode = hashCode * -1521134295 + CCNumber.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CCExpiryDate);
      return hashCode;
    }
  }
}