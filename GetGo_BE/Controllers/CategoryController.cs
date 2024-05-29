using GetGo.Domain.Models;
using GetGo_BE.Constants;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GetGo_BE.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoryController : BaseController<CategoryController>
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService) : base(logger)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet(ApiEndPointConstant.Category.CategoriesEndpoint)]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get Category List")]
        public async Task<IActionResult> GetCategoryList()
        {
            var result = await _categoryService.GetCategoryList();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet(ApiEndPointConstant.Category.CategoryEndpoint)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get a category by its id")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var result = await _categoryService.GetCategoryById(id);
            return Ok(result);  
        }

        [HttpPost(ApiEndPointConstant.Category.CategoriesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create new category")]
        public async Task<IActionResult> CreateCategory(string name)
        {
            await _categoryService.CreateCategory(name);
            return Ok("Action successs");
        }

        [HttpPatch(ApiEndPointConstant.Category.CategoriesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update an exist category")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await _categoryService.UpdateCategory(category);
            return Ok("Action success");
        }
    }
}
