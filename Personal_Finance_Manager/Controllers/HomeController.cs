using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Personal_Finance_Manager.ViewModels;
using ServiceContracts;
using Services;
using Services.Data;
using System.Diagnostics;

namespace Personal_Finance_Manager.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IDatabaseService _databaseService;
        private readonly ICategoriesService _categoriesService;

		public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IDatabaseService databaseService,
                                ICategoriesService categoriesService)
		{
            _appDbContext = appDbContext;
			_logger = logger;
            _databaseService = databaseService;
            _categoriesService = categoriesService;
		}

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            var (IsConnected, ErrorMessage) = _databaseService.CanConnect();

            if (IsConnected)
            {
                string databaseName = _appDbContext.Database.GetDbConnection().Database;

                viewModel.ConnectionStatus = $"Connected to [{databaseName}] database!";
                viewModel.ConnectionStatusColor = "text-done";
                viewModel.Categories = _categoriesService.GetCategories();
                viewModel.TransactionCount = _appDbContext.Transactions.Count();
            }
            else if (!string.IsNullOrEmpty(ErrorMessage))
            {
                viewModel.ConnectionStatus = "Connection error!";
                viewModel.ErrorMessage = ErrorMessage;
                viewModel.ConnectionStatusColor = "text-danger";
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}