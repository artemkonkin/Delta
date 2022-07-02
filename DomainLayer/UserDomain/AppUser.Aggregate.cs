using System.ComponentModel.DataAnnotations;

namespace UserDomain;

public partial class AppUser
{
    public AppUser(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }

    public bool ValidOnAdd()
    {
        return
            !string.IsNullOrEmpty(UserName)
            && !string.IsNullOrEmpty(Email)
            && new EmailAddressAttribute().IsValid(Email);
    }
}