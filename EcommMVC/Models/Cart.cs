namespace EcommMVC.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public class Cart
  {

    public long CartId { get; set; }

    public long ItemId { get; set; }

    public long UserId { get; set; }

    public string ItemName { get; set; }

    public int ItemQuantity { get; set; }

    public float ItemPrice { get; set; }

    public override bool Equals(object obj)
    {
      return obj is Cart cart &&
             CartId == cart.CartId &&
             ItemId == cart.ItemId &&
             UserId == cart.UserId &&
             ItemName == cart.ItemName &&
             ItemQuantity == cart.ItemQuantity &&
             ItemPrice == cart.ItemPrice;
    }

    public override int GetHashCode()
    {
      int hashCode = 1170749335;
      hashCode = hashCode * -1521134295 + CartId.GetHashCode();
      hashCode = hashCode * -1521134295 + ItemId.GetHashCode();
      hashCode = hashCode * -1521134295 + UserId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
      hashCode = hashCode * -1521134295 + ItemQuantity.GetHashCode();
      hashCode = hashCode * -1521134295 + ItemPrice.GetHashCode();
      return hashCode;
    }

    public Cart(long cartId, long itemId, long userId, string itemName, int itemQuantity, float itemPrice)
    {
      this.CartId = cartId;
      this.ItemId = itemId;
      this.UserId = userId;
      this.ItemName = itemName;
      this.ItemQuantity = itemQuantity;
      this.ItemPrice = itemPrice;
    }
  }
}