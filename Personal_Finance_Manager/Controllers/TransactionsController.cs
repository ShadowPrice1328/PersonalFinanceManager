﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Data;
using ServiceContracts.DTO;
using ServiceContracts;
using Personal_Finance_Manager.ViewModels;
using Entities;

namespace Personal_Finance_Manager.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IDatabaseService _databaseService; 
        private readonly ITransactionsService _transactionsService;
        private readonly ICategoriesService _categoriesService;

        public TransactionsController(IDatabaseService databaseService, ITransactionsService transactionsService, ICategoriesService categoriesService)
        {
            _databaseService = databaseService;
            _transactionsService = transactionsService;
            _categoriesService = categoriesService;
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
            var viewModel = new TransactionViewModel
            {
                Transactions = _transactionsService.GetTransactions(),
                CategoryNames = _transactionsService.GetTransactionsCategoriesNames()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryNames = _categoriesService.GetCategoryNames();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TransactionAddRequest request)
        {
            if (ModelState.IsValid)
            {
                _transactionsService.AddTransaction(request);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            var selectedTransaction = _transactionsService.GetTransactionByTransactionId(Id);

            ViewBag.CategoryNames = _categoriesService.GetCategoryNames();
            return View(selectedTransaction);
        }

        [HttpPost]
        public IActionResult Edit(TransactionUpdateRequest request)
        {
            _transactionsService.UpdateTransaction(request);

            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid Id)
        {
            var selectedTransaction = _transactionsService.GetTransactionByTransactionId(Id);

            return View(selectedTransaction);
        }
        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            TransactionResponse? transactionResponse = _transactionsService.GetTransactionByTransactionId(Id);

            return View(transactionResponse);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(Guid Id)
        {
            _transactionsService.DeleteTransaction(Id);

            return RedirectToAction("Index");
        }

        [Route("[controller]/filter-by/{filterBy?}/{filterString?}")]
        public IActionResult Filter(string filterBy, string filterString)
        {
            if (filterString != "Select Category" && !string.IsNullOrEmpty(filterString))
            {
                var filterResult = _transactionsService.GetFilteredTransactions(filterBy, filterString);

                return PartialView("_TransactionsPartial", filterResult);
            }

            return PartialView("_TransactionsPartial", _transactionsService.GetTransactions());
        }
    }
}
