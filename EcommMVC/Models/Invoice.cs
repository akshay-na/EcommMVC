using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EcommMVC.Models
{
  public class Invoice
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceId { get; set; }
    [Required]
    public long OrderId { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public DateTime OrderedOn { get; set; } = DateTime.Now;
    [Required]
    public double TotalAmount { get; set; }

    [JsonIgnore]
    [ForeignKey("UserId")]
    [StringLength(128)]
    public virtual ApplicationUser User { get; set; }
    [JsonIgnore]
    [ForeignKey("OrderId")]
    public virtual Order order { get; set; }

    public Invoice()
    {

    }

    public override bool Equals(object obj)
    {
      return obj is Invoice invoice &&
             InvoiceId == invoice.InvoiceId &&
             EqualityComparer<long>.Default.Equals(OrderId, invoice.OrderId) &&
             UserId == invoice.UserId &&
             OrderedOn == invoice.OrderedOn &&
             TotalAmount == invoice.TotalAmount;
    }

    public override int GetHashCode()
    {
      int hashCode = -961932098;
      hashCode = hashCode * -1521134295 + InvoiceId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<long>.Default.GetHashCode(OrderId);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
      hashCode = hashCode * -1521134295 + OrderedOn.GetHashCode();
      hashCode = hashCode * -1521134295 + TotalAmount.GetHashCode();
      return hashCode;
    }
  }
}