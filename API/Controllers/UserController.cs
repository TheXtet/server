using Interfaces;
using Interfaces.DTO;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/user
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get() 
        {
            List<UserDTO> users = new List<UserDTO>();

            IUsers usersGrain = _client.GetGrain<IUsers>(0);
            foreach (var userName in await usersGrain.Get())
            {
                users.Add(await _client.GetGrain<IUser>(userName).Get());
            }

            return await Task.FromResult(users.AsEnumerable());
        }

        // GET: api/user/username
        [HttpGet("{username}")]
        public Task<UserDTO> Get(string username) => _client.GetGrain<IUser>(username).Get();

        // GET: api/user/username/password
        [HttpGet("{username}/{password}")]
        public Task<bool> CheckPassword(string username, string password) => _client.GetGrain<IUser>(username).CheckPassword(password);

        // POST api/user
        [HttpPost]
        public Task Post([FromBody] UserDTO user) => _client.GetGrain<IUser>(user.Login).Update(user);
    }
}