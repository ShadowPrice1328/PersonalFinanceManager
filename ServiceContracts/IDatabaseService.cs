using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Checks whether it is possible to connect to the database
        /// </summary>
        /// <returns>A tuple with information about connection</returns>
        (bool IsConnected, string? ErrorMessage) CanConnect();
    }
}
