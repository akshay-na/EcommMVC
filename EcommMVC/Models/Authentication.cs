using System.Collections.Generic;

namespace EcommMVC.Models
{
  public class Authentication
  {

    public bool LoginStatus { get; set; } = false;
    public Users CurrentUsers { get; set; } = null;

    public Authentication()
    {

    }
    public Authentication(bool loginStatus, Users currentUsers)
    {
      this.LoginStatus = loginStatus;
      this.CurrentUsers = currentUsers;

    }

    public override bool Equals(object obj)
    {
      return obj is Authentication authentication &&
             LoginStatus == authentication.LoginStatus &&
             EqualityComparer<Users>.Default.Equals(CurrentUsers, authentication.CurrentUsers);
    }

    public override int GetHashCode()
    {
      int hashCode = -1510095610;
      hashCode = hashCode * -1521134295 + LoginStatus.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<Users>.Default.GetHashCode(CurrentUsers);
      return hashCode;
    }
  }
}