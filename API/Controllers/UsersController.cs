using Interfaces;
using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGrainFactory _client;
        private readonly IUsers _grain;

        public UsersController(IGrainFactory client)
        {
            _client = client;
            _grain = _client.GetGrain<IUsers>(0);
        }

        // GET: api/users
        [HttpGet]
        public Task<IEnumerable<string>> Get() => _grain.Get();

        // POST api/users
        [HttpPost]
        public Task Post([FromBody] UserPost value) => _grain.Add(value.Parametr);

        // DELETE api/users/username
        [HttpDelete("{id}")]
        public Task Delete(string id) => _grain.Remove(id);

    }
}