using UserApi.Models;
namespace UserApi.Services;
public class UserDataStore
{
    public List<User> Users { get; set; }
    public static UserDataStore Current { get; } = new UserDataStore();
    public UserDataStore()
    {
        Users = [
              new() {
                Id = "1",
               Name = "Daniel Alejandro",
                Email = "danny95gh@gmail.com",
            },
             new() {
                Id = "2",
               Name = "Andres Gallardo",
                Email = "andres@gmail.com",
            }
        ];
    }
}
