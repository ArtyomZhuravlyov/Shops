using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shops.Contracts.Dto.Metrics;
using Shops.Contracts.Dto.Shop;
using Shops.DataAccess.Entities;
using Shops.Server.Interfaces;
using Shops.Server.Services;


namespace Shops.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        /// <summary>
        /// Получение всех магазинов
        /// </summary>
        /// <returns>все магазины</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShopDto>>> GetAll()
        {
            return Ok(await _shopService.GetAll());
        }

        /// <summary>
        /// Получение магазина по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Магазин</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDto>> GetById(int id)
        {
            var shop = await _shopService.GetById(id);
            if (shop == null)
                return NotFound();

            return Ok(shop);
        }

        /// <summary>
        /// Создание магазина
        /// </summary>
        /// <param name="value">Магазин</param>
        /// <returns>Созданный магазин</returns>
        [HttpPost]
        public async Task<ActionResult<ShopDto>> Create(CreateRequestShopDto shop)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _shopService.Create(shop));
            }
            else
                return BadRequest();

        }

        /// <summary>
        /// Обновление магазина
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Обновленный магазин</returns>
        [HttpPut]
        public async Task<ActionResult<ShopDto>> Update(ShopDto shop)
        {
            if (ModelState.IsValid)
            {
                if (await _shopService.Update(shop) != null)
                    return Ok();
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        /// <summary>
        /// Удаление магазина
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok или BadRequest</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _shopService.Delete(id))
                return Ok();
            else
                return BadRequest();
        }


        /// <summary>
        /// Получение метрик общий запас, точность запасов, наличие на полу, 
        /// средний возраст запасов по магазинам и минимальное, среднее, максимальное значение
        /// </summary>
        /// <returns>все магазины</returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<MetricDto>> GetMetric()
        {
            return Ok(await _shopService.GetMetric());
        }
    }
}
