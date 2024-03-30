using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controller;



[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(UserDataStore.Current.Users);
    }

    [HttpGet("{idUser}")]
    public ActionResult<User> GetUser(string idUser)
    {
        var user = UserDataStore.Current.Users.Find(u => u.Id == idUser);
        if (user == null)
            return NotFound("No existe");
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> PostUser(UserInsert user)
    {
        var maxId = UserDataStore.Current.Users.Max(x => x.Id);
        var newUser = new User()
        {
            Id = maxId + 1,
            Name = user.Name,
            Email = user.Email
        };

        UserDataStore.Current.Users.Add(newUser);
        return CreatedAtAction(nameof(GetUser),
           new { idUser = newUser.Id },
           newUser
       );
    }

    [HttpPut("{userId}")]
    public ActionResult<User> PutUser([FromRoute] string userId, [FromBody] UserInsert userInsert)
    {
        var user = UserDataStore.Current.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("No existe");

        user.Name = userInsert.Name;
        user.Email = userInsert.Email;

        return NoContent();

    }


}