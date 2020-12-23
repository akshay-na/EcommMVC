using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommMVC.Models
{
  public class Order
  {

    public long OrderId { get; set; }
    public string UserId { get; set; }
    public string CCAddress { get; set; }
    public string CCName { get; set; }
    public int CCNumber { get; set; }
    public string CCExpiryDate { get; set; }

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