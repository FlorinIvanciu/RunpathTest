using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Core;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RunpathTest.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTableController : ControllerBase
    {
        private readonly IDataHandler dataHandler;

        public DataTableController(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler ?? throw new ArgumentNullException(nameof(dataHandler));
        }

        [HttpGet]
        public async Task<IEnumerable<DataTableModel>> GetDataAsync()
        {
            return await dataHandler.GetDataTableAsync();
        }
    }
}