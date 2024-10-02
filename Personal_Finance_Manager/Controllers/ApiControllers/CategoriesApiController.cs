using Entities;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Services;

namespace Personal_Finance_Manager.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        public CategoriesApiController(FinanceService financeService)
        {
            _financeService = financeService;
        }

        private readonly FinanceService _financeService;

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _financeService.GetCategories();
        }

        [Route("get-specific/{name}")]
        [HttpGet]
        public Category GetCategory(string name)
        {
            return _financeService.GetCategory(name);
        }
    }
}
