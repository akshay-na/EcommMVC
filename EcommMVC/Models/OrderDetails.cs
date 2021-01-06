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
        [StringLength(128)]
        public string OrderId { get; set; }
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
            return obj is OrderDetails details &&
                   Id == details.Id &&
                   OrderId == details.OrderId &&
                   ProductId == details.ProductId &&
                   UserId == details.UserId &&
                   ItemName == details.ItemName &&
                   TotalPrice == details.TotalPrice &&
                   ItemQuantity == details.ItemQuantity &&
                   OrderStatus == details.OrderStatus &&
                   DeliverStatus == details.DeliverStatus;
        }

        public override int GetHashCode()
        {
            int hashCode = -2059430959;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderId);
            hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + ItemQuantity.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderStatus);
            hashCode = hashCode * -1521134295 + DeliverStatus.GetHashCode();
            return hashCode;
        }
    }
}