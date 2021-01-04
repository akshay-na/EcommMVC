using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace EcommMVC.Models
{
  public class ProductDetails
  {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ProductId { get; set; }

    [Required] [StringLength(128)]
    public string VendorId { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public int ProductQuantity { get; set; }
    [Required]
    public float ProductPrice { get; set; }
    [Required]
    public string ProductCategory { get; set; }

    public string ProductPicPath { get; set; }


    public ProductDetails()
    {

    }

    public ProductDetails(string vendorId, long productId, string productName, int productQuantity, float productPrice, string productCategory)
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
      return obj is ProductDetails products &&
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