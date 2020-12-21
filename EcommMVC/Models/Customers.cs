using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommMVC.Models
{
  public class Customers
  {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerFullName { get; set; }
    public int CustomerPasswordHashed { get; set; }
    public string CustomerEmail { get; set; }
    public float CustomerWallet { get; set; }
    public string CustomerRole { get; set; }

    public Customers()
    {

    }

    public Customers(long CustomerId, string CustomerName, string CustomerFullName, int CustomerPasswordHashed, string CustomerEmail, float CustomerWallet, string CustomerRole)
    {
      this.CustomerId = CustomerId;
      this.CustomerName = CustomerName;
      this.CustomerFullName = CustomerFullName;
      this.CustomerPasswordHashed = CustomerPasswordHashed;
      this.CustomerEmail = CustomerEmail;
      this.CustomerWallet = CustomerWallet;
      this.CustomerRole = CustomerRole;

    }

    public override bool Equals(object obj)
    {
      return obj is Customers Customers &&
             CustomerId == Customers.CustomerId &&
             CustomerName == Customers.CustomerName &&
             CustomerFullName == Customers.CustomerFullName &&
             CustomerPasswordHashed == Customers.CustomerPasswordHashed &&
             CustomerEmail == Customers.CustomerEmail &&
             CustomerWallet == Customers.CustomerWallet &&
             CustomerRole == Customers.CustomerRole;
    }

    public override int GetHashCode()
    {
      int hashCode = -1012319599;
      hashCode = hashCode * -1521134295 + CustomerId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerFullName);
      hashCode = hashCode * -1521134295 + CustomerPasswordHashed.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerEmail);
      hashCode = hashCode * -1521134295 + CustomerWallet.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerRole);
      return hashCode;
    }
  }
}