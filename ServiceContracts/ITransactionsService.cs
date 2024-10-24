﻿using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ITransactionsService
    {
        /// <summary>
        /// Retrives all transactions presented in database
        /// </summary>
        /// <returns>A list of TransactionResponse objects</returns>
        List<TransactionResponse> GetTransactions();

        /// <summary>
        /// Retrives selected transaction according to id
        /// </summary>
        /// <param name="transactionId">Id of transaction to get</param>
        /// <returns>TransactionResponse with all the information about selected transaction</returns>
        TransactionResponse? GetTransactionByTransactionId(Guid? transactionId);

        /// <summary>
        /// Adds transaction to database
        /// </summary>
        /// <param name="request">Transaction to add</param>
        /// <returns>The same details but with generated Guid</returns>
        TransactionResponse AddTransaction(TransactionAddRequest? request);

        /// <summary>
        /// Updates information about transaction
        /// </summary>
        /// <param name="request">Transaction to update</param>
        /// <returns>CategoryResponse with updated information about category</returns>
        TransactionResponse UpdateTransaction(TransactionUpdateRequest? request);

        /// <summary>
        /// Removes transaction from database
        /// </summary>
        /// <param name="guid">Id of transaction to remove</param>
        /// <returns>True if success, false if error has occured</returns>
        bool DeleteTransaction(Guid? guid);

        /// <summary>
        /// Retrives all transactions that match filter parameters
        /// </summary>
        /// <param name="filterBy"></param>
        /// <param name="filterString"></param>
        /// <returns>A list of filtered TransactionResponses</returns>
        List<TransactionResponse> GetFilteredTransactions(string filterBy, string? filterString);

        /// <summary>
        /// Retrives all transaction made between two dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>A list of selected TransactionRepsponses</returns>
        List<TransactionResponse> GetTransactionBetweenTwoDates(DateTime? startDate, DateTime? endDate);

        /// <summary>
        /// Retrives all categories names of present transactions
        /// </summary>
        /// <returns>A list of names of categories</returns>
        List<string?> GetTransactionsCategoriesNames();
    }
}
