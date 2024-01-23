using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // to get List of records
        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await (from Languages in _appDbContext.Languages select Languages).ToListAsync();
            return Ok(result);
        }

        // get record using Primary Key
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageByIdAsyns([FromRoute] int id)
        {
            var result = await _appDbContext.Languages.FindAsync(id);
            return Ok(result);
        }

    }
}
