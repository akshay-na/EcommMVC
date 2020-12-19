using System.Collections.Generic;

namespace EcommMVC.Models
{
  public class Orders
  {

    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public string ItemName { get; set; }
    public float TotalPrice { get; set; }
    public int ItemQuantity { get; set; }
    public string OrderStatus { get; set; }
    public bool DeliverStatus { get; set; }

    public Orders()
    {

    }

    public Orders(long orderId, long userId, string itemName, float totalPrice, int itemQuantity, string orderStatus, bool deliverStatus, long productId)
    {
      this.OrderId = orderId;
      this.UserId = userId;
      this.ItemName = itemName;
      this.TotalPrice = totalPrice;
      this.ItemQuantity = itemQuantity;
      this.OrderStatus = orderStatus;
      this.DeliverStatus = deliverStatus;
      this.ProductId = productId;
    }

    public override bool Equals(object obj)
    {
      return obj is Orders orders &&
             OrderId == orders.OrderId &&
             ProductId == orders.ProductId &&
             UserId == orders.UserId &&
             ItemName == orders.ItemName &&
             TotalPrice == orders.TotalPrice &&
             ItemQuantity == orders.ItemQuantity &&
             OrderStatus == orders.OrderStatus &&
             DeliverStatus == orders.DeliverStatus;
    }

    public override int GetHashCode()
    {
      int hashCode = 88120017;
      hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
      hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
      hashCode = hashCode * -1521134295 + UserId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
      hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
      hashCode = hashCode * -1521134295 + ItemQuantity.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderStatus);
      hashCode = hashCode * -1521134295 + DeliverStatus.GetHashCode();
      return hashCode;
    }
  }
}