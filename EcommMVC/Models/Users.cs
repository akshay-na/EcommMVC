using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommMVC.Models
{
  public class Users
  {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string UserFullName { get; set; }
    public int UserPasswordHashed { get; set; }
    public string UserEmail { get; set; }
    public float UserWallet { get; set; }
    public string UserRole { get; set; }

    public Users()
    {

    }

    public Users(long userId, string userName, string userFullName, int userPasswordHashed, string userEmail, float userWallet, string userRole)
    {
      this.UserId = userId;
      this.UserName = userName;
      this.UserFullName = userFullName;
      this.UserPasswordHashed = userPasswordHashed;
      this.UserEmail = userEmail;
      this.UserWallet = userWallet;
      this.UserRole = userRole;

    }

    public override bool Equals(object obj)
    {
      return obj is Users users &&
             UserId == users.UserId &&
             UserName == users.UserName &&
             UserFullName == users.UserFullName &&
             UserPasswordHashed == users.UserPasswordHashed &&
             UserEmail == users.UserEmail &&
             UserWallet == users.UserWallet &&
             UserRole == users.UserRole;
    }

    public override int GetHashCode()
    {
      int hashCode = -1012319599;
      hashCode = hashCode * -1521134295 + UserId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserFullName);
      hashCode = hashCode * -1521134295 + UserPasswordHashed.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserEmail);
      hashCode = hashCode * -1521134295 + UserWallet.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserRole);
      return hashCode;
    }
  }
}