using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Personal_Finance_Manager.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesApiController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [Route("get-all")]
        [HttpGet]
        public List<CategoryResponse> GetCategories()
        {
            return _categoriesService.GetCategories();
        }

        [Route("get-specific/{id}")]
        [HttpGet]
        public CategoryResponse? GetCategory(Guid id)
        {
            return _categoriesService.GetCategoryByCategoryId(id);
        }
    }
}
