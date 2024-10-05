using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Data;

namespace Personal_Finance_Manager.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDatabaseService _databaseService;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService, IDatabaseService databaseService)
        {
            //_appDbContext = appDbContext;
            _databaseService = databaseService;
            _categoriesService = categoriesService;
        }

        // Returning to Index if problem with connection
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_databaseService.CanConnect().IsConnected)
            {
                context.Result = RedirectToAction("Index", "Home");
            }

            base.OnActionExecuting(context);
        }

        public IActionResult Index()
        {
            var allCategories = _categoriesService.GetCategories();

            return View(allCategories);
        }

        [Route("[controller]/search/{categoryName}")]
        public IActionResult Search(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                categoryName = categoryName.Trim().ToLower();

                var searchResults = _categoriesService.GetFilteredCategories(nameof(CategoryResponse.Name), categoryName);

                if (searchResults.Count != 0)
                    TempData["AfterSearch"] = true;
                else
                    TempData["Message"] = "Nothing found!";

                return PartialView("_CategoriesPartial", searchResults);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryAddRequest request)
        {
            if (ModelState.IsValid)
            {
                _categoriesService.AddCategory(request);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var selectedCategory = _categoriesService.GetCategoryByCategoryId(id);

            return View(selectedCategory);
        }

        [HttpPost]
        public ActionResult Edit(CategoryUpdateRequest request)
        {
            _categoriesService.UpdateCategory(request);

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var selectedCategory = _categoriesService.GetCategoryByCategoryId(id);

            return View(selectedCategory);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var selectedCategory = _categoriesService.GetCategoryByCategoryId(id);

            return View(selectedCategory);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(Guid id)
        {
            _categoriesService.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}
