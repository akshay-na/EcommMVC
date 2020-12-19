using System.Collections.Generic;

namespace EcommMVC.Models
{
  public class Products
  {

    public long VendorId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductQuantity { get; set; }
    public float ProductPrice { get; set; }
    public string ProductCategory { get; set; }

    public Products()
    {

    }

    public Products(long vendorId, long productId, string productName, int productQuantity, float productPrice, string productCategory)
    {
      this.VendorId = vendorId;
      this.ProductId = productId;
      this.ProductName = productName;
      this.ProductQuantity = productQuantity;
      this.ProductPrice = productPrice;
      this.ProductCategory = productCategory;

    }

    public override bool Equals(object obj)
    {
      return obj is Products products &&
             VendorId == products.VendorId &&
             ProductId == products.ProductId &&
             ProductName == products.ProductName &&
             ProductQuantity == products.ProductQuantity &&
             ProductPrice == products.ProductPrice &&
             ProductCategory == products.ProductCategory;
    }

    public override int GetHashCode()
    {
      int hashCode = 359623620;
      hashCode = hashCode * -1521134295 + VendorId.GetHashCode();
      hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
      hashCode = hashCode * -1521134295 + ProductQuantity.GetHashCode();
      hashCode = hashCode * -1521134295 + ProductPrice.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductCategory);
      return hashCode;
    }
  }
}