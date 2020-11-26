using Interfaces;
using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaController : ControllerBase
    {
        private readonly IGrainFactory _client;
        private readonly IFormula _grain;

        public FormulaController(IGrainFactory client)
        {
            _client = client;
            _grain = _client.GetGrain<IFormula>(0);
        }

        // GET: api/formula
        [HttpGet]
        public Task<Formula> Get() => _grain.GetFormula();

        // POST api/formula
        [HttpPost]
        public Task Post([FromBody] Formula formula) => _grain.SetFormula(formula);
    }
}