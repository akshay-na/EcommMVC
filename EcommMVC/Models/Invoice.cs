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
        [ForeignKey("OrderId")]
        public List<int> OrderId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        [StringLength(128)]
        public string UserId { get; set; }
        [Required]
        public DateTime OrderedOn { get; set; } = DateTime.Now;
        [Required]
        public double TotalAmount { get; set; }
        
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
        [JsonIgnore]
        public virtual OrderDetails Order { get; set; }

    }
}