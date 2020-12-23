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
    public long Id { get; set; }
    [Required]
    public long OrderId { get; set; }
    [Required]
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    [Required]
    [StringLength(128)]
    public string UserId { get; set; }
    public string ItemName { get; set; }
    public float TotalPrice { get; set; }
    public int ItemQuantity { get; set; }
    public string OrderStatus { get; set; }
    public bool DeliverStatus { get; set; }

    [JsonIgnore]
    public virtual ProductDetails Product { get; set; }
    [JsonIgnore]
    [ForeignKey("OrderId")]
    public virtual Order order { get; set; }


        public OrderDetails()
    {

    }

    public OrderDetails(long id, string userId, string itemName, float totalPrice, int itemQuantity, string orderStatus, bool deliverStatus, long productId)
    {
      this.Id = id;
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
             Id == orders.Id &&
             ProductId == orders.ProductId &&
             UserId == orders.UserId &&
             ItemName == orders.ItemName &&
             TotalPrice == orders.TotalPrice &&
             ItemQuantity == orders.ItemQuantity &&
             OrderStatus == orders.OrderStatus &&
             DeliverStatus == orders.DeliverStatus &&
             OrderId == orders.OrderId;
    }

    public override int GetHashCode()
    {
      int hashCode = 88120017;
      hashCode = hashCode * -1521134295 + Id.GetHashCode();
      hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
      hashCode = hashCode * -1521134295 + UserId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
      hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
      hashCode = hashCode * -1521134295 + ItemQuantity.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderStatus);
      hashCode = hashCode * -1521134295 + DeliverStatus.GetHashCode();
      hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
      return hashCode;
    }
  }
}