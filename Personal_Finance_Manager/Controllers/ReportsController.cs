using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Personal_Finance_Manager.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IDatabaseService _databaseService;
        private readonly ICategoriesService _categoriesService;
        private readonly IReportService _reportService;
        private readonly ITransactionsService _transactionsService;

        public ReportsController(IDatabaseService databaseService, ICategoriesService categoriesService, 
                                    IReportService reportService, ITransactionsService transactionsService)
        {
            _databaseService = databaseService;
            _categoriesService = categoriesService;
            _reportService = reportService;
            _transactionsService = transactionsService;
        }

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
            ViewBag.CategoryNames = _transactionsService.GetTransactionsCategoriesNames();
            return View();
        }
        [HttpPost]
        public IActionResult Graph(GenerateReportRequest request)
        {
            var viewModel = _reportService.GenerateReport(request, false);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Generate(GenerateReportRequest request)
        {
            bool withCategory = !string.IsNullOrEmpty(request.Category);
            var viewModel = _reportService.GenerateReport(request, withCategory);

            return View(viewModel);
        }
    }
}
