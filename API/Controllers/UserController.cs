using Interfaces;
using Interfaces.DTO;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGrainFactory _client;

        public UserController(IGrainFactory client)
        {
            _client = client;
        }

        // GET: api/user/username
        [HttpGet("{username}")]
        public Task<UserDTO> Get(string username) => _client.GetGrain<IUser>(username).Get();

        // GET: api/user/username/password
        [HttpGet("{username}/{password}")]
        public Task<bool> CheckPassword(string username, string password) => _client.GetGrain<IUser>(username).CheckPassword(password);

        // POST api/user
        [HttpPost]
        public Task Post([FromBody] UserLoginDTO user) => _client.GetGrain<IUser>(user.UserName).Update(user);
    }
}