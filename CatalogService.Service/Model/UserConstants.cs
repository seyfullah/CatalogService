namespace CatalogService.Service.Model;

// We are not taking data from data base so we get data from constant
public class UserConstants
{
    public static List<UserModel> Users = new()
    {
        new UserModel() { Username = "ali", Password = "ali", Role = "Admin" },
        new UserModel() { Username = "veli", Password = "veli", Role = "Moderator" },
        new UserModel() { Username = "cem", Password = "cem", Role = "Viewer" }
    };
}
