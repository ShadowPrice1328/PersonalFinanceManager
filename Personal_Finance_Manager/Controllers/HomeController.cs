using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Personal_Finance_Manager.ViewModels;
using Services.Data;
using System.Diagnostics;

namespace Personal_Finance_Manager.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

		public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
		{
            _appDbContext = appDbContext;
			_logger = logger;
		}

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            // Checking Database connections
            try
            {
                using (_appDbContext.Database.GetDbConnection())
                {
                    _appDbContext.Database.OpenConnection();
                    viewModel.IsConnected = _appDbContext.Database.CanConnect();
                    _appDbContext.Database.CloseConnection();

                    // Showing a message about connection status
                    if (viewModel.IsConnected)
                    {
                        string databaseName = _appDbContext.Database.GetDbConnection().Database;

                        viewModel.ConnectionStatus = $"Connected to [{databaseName}] database!";
                        viewModel.ConnectionStatusColor = "text-done";
                        viewModel.Categories = _appDbContext.Categories.ToList();
                        viewModel.TransactionCount = _appDbContext.Transactions.Count();
                    }
                    else
                    {
                        viewModel.ConnectionStatus = "Not Connected!";
                        viewModel.ConnectionStatusColor = "text-warning";
                    }
                }
            }
            catch (Exception ex)
            {
                viewModel.ConnectionStatus = "Connection error!";
                viewModel.ErrorMessage = ex.Message;
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