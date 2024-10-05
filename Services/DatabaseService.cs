using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ServiceContracts;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly AppDbContext _appDbContext;
        public DatabaseService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public (bool IsConnected, string? ErrorMessage) CanConnect()
        {
            try
            {
                using (_appDbContext.Database.GetDbConnection())
                {
                    _appDbContext.Database.OpenConnection();
                    bool IsConnected = _appDbContext.Database.CanConnect();
                    _appDbContext.Database.CloseConnection();

                    return (true, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
