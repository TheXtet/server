using Interfaces.Models;
using Orleans;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFormula : IGrainWithIntegerKey
    {
        Task<Formula> GetFormula();
        Task SetFormula(Formula formula);
    }
}