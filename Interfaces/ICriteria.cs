using Interfaces.Models;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICriteria : IGrainWithIntegerKey
    {
        Task Add(string name, string abbreviation);
        Task Disable(string abbreviation);
        Task<IEnumerable<Сriteria>> Get();
        Task Activate(string abbreviation);
    }
}