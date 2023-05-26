using Microsoft.AspNetCore.Mvc;
using Shops.Contracts.Dto.Category;
using Shops.Contracts.Dto.Shop;
using Shops.DataAccess.Entities;
using Shops.Server.Interfaces;
using Shops.Server.Services;


namespace Shops.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Получение всех категорий
        /// </summary>
        /// <returns>все категории</returns>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        /// <summary>
        /// Получение категории по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>категория</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

    }
}
