using Interfaces;
using Orleans;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grains
{
    public class UsersGrain : Grain<UsersArchive>, IUsers
    {
        public async Task Add(string username)
        {
            if (this.State.Users.Contains(username))
            {
                return;
            }

            this.State.Users.Add(username);
            await WriteStateAsync();
        }

        public Task<IEnumerable<string>> Get() => Task.FromResult(this.State.Users.AsEnumerable());

        public async Task Remove(string username)
        {
            if (this.State.Users.Contains(username))
            {
                this.State.Users.Remove(username);
                await WriteStateAsync();
            }
        }
    }

    public class UsersArchive
    {
        public List<string> Users { get; } = new List<string>();
    }
}