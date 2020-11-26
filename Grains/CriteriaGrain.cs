using Interfaces;
using Interfaces.Models;
using Orleans;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grains
{
    public class CriteriaGrain : Grain<CriteriaArchive>, ICriteria
    {
        public async Task Activate(string abbreviation)
        {
            Сriteria criteria = this.State.Criterias.First(item => item.Abbreviation == abbreviation);
            
            if (criteria == null)
            {
                return;
            }

            criteria.IsEnabled = true;
            await this.WriteStateAsync();
        }

        public async Task Add(string name, string abbreviation)
        {
            this.State.Criterias.Add(new Сriteria(name, abbreviation, true));
            await WriteStateAsync();
        }

        public async Task Disable(string abbreviation)
        {
            this.State.Criterias.First(item => item.Abbreviation == abbreviation).IsEnabled = false;
            await WriteStateAsync();
        }

        public Task<IEnumerable<Сriteria>> Get() => Task.FromResult(this.State.Criterias.AsEnumerable());
    }

    public class CriteriaArchive
    {
        public List<Сriteria> Criterias { get; } = new List<Сriteria>();
    }
}