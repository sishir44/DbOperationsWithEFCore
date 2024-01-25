using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = _appDbContext.Currencies.ToList();
            //var result = (from currencies in _appDbContext.Currencies select currencies).ToList();

            var result =   await (from currencies in _appDbContext.Currencies select currencies).ToListAsync();
            return Ok(result);
        }

        // get 1 record using Name
        [HttpGet("{name}/{description}")]
        public async Task<IActionResult> GetCurrencyByNameAsyns([FromRoute] string name, [FromRoute] string? description)
        {
            var result = await _appDbContext.Currencies
                .FirstOrDefaultAsync(x =>
                x.Title == name &&
                (string.IsNullOrEmpty(description) || x.Description == description));
            return Ok(result);
        }

        // Get all records using multiple parameter
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyListByNameAsyns([FromRoute] string name, [FromQuery] string? description)
        {
            // High perfoemance
            var result = await _appDbContext.Currencies
                .Where(x => 
                x.Title == name &&
                (string.IsNullOrEmpty(description) || x.Description == description)).ToListAsync();
            return Ok(result);
        }

        // Get records based on dynamic ids 
        [HttpPost("all")]
        public async Task<IActionResult> GetCurrencyByIdsAsyns([FromBody] List<int> ids)
        {
            var result = await _appDbContext.Currencies
                .Where(x =>ids.Contains(x.Id))
                .Select(x=> new Currency()
                {
                    Id = x.Id,
                    Title = x.Title,
                }).ToListAsync();
            return Ok(result);
        }
    }

}
