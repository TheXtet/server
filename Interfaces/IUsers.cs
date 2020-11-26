using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsers : IGrainWithIntegerKey
    {
        Task Add(string username);
        Task Remove(string username);
        Task<IEnumerable<string>> Get();
    }
}