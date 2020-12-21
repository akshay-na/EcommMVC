using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Newtonsoft.Json;

namespace EcommMVC.Models
{
  public class OrderDetails
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OrderId { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    [ForeignKey("User")]
    public long UserId { get; set; }
    public string ItemName { get; set; }
    public float TotalPrice { get; set; }
    public int ItemQuantity { get; set; }
    public string OrderStatus { get; set; }
    public bool DeliverStatus { get; set; }

    [JsonIgnore]
    public virtual ProductDetails Product { get; set; }
    [JsonIgnore]
    public virtual Users User { get; set; }

        public OrderDetails()
    {

    }

    public OrderDetails(long orderId, long userId, string itemName, float totalPrice, int itemQuantity, string orderStatus, bool deliverStatus, long productId)
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
      return obj is OrderDetails orders &&
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