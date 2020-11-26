using Interfaces;
using Interfaces.Models;
using Orleans;
using System.Threading.Tasks;

namespace Grains
{
    public class FormulaGrain : Grain<FormulaArchive>, IFormula
    {
        public Task<Formula> GetFormula() => Task.FromResult(new Formula(this.State.Value));

        public async Task SetFormula(Formula value)
        {
            if (value != null)
            {
                this.State.Value = value.Value;
                await this.WriteStateAsync();
            }
        }
    }

    public class FormulaArchive
    {
        public string Value { get; set; }
    }
}