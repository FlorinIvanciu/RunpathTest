using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Core;
using Data.Models;
using Microsoft.AspNetCore.Mvc;


namespace RunpathTest.Controllers.Api
{
    [Route("api/[controller]")]
    public class DataTableController : Controller
    {
        private readonly IDataHandler dataHandler;

        public DataTableController(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<DataTableModel>> GetDataAsync()
        {
            return await dataHandler.GetDataTableAsync();
        }

    }
}
