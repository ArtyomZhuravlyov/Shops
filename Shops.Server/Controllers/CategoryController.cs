using Microsoft.AspNetCore.Mvc;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Country;
using Shops.Contracts.Dto.Shop;
using Shops.DataAccess.Entities;
using Shops.Server.Interfaces;
using Shops.Server.Services;


namespace Shops.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Получение всех стран
        /// </summary>
        /// <returns>все страны</returns>
        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> GetAll()
        {
            return Ok(await _countryService.GetAll());
        }

        /// <summary>
        /// Получение страны по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>страна</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var country = await _countryService.GetById(id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

    }
}
