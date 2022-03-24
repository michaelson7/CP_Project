using API.Services;
using Applicationn.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IDataService _db;
        public JsonResponses _response = new JsonResponses();

        public TransactionController(IDataService db)
        {
            _db = db;
        }

        //get
        [HttpGet]
        [Route("getStatTransaction")]
        public async Task<ActionResult<TransactionStats>> getStatTransaction()
        {
            try
            {
                var output = await _db.TransactionStatsGet();
                return _response.getResponse(output, "Trans not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        [HttpGet]
        [Route("StatsGetByWeek")]
        public async Task<ActionResult<IEnumerable<MoneyStats>>> StatsGetByWeek()
        {
            try
            {
                var output = await _db.StatsGetByWeek();
                return _response.getResponse(output, "Services not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        [HttpGet]
        [Route("StatsGetByYear")]
        public async Task<ActionResult<IEnumerable<MoneyStats>>> StatsGetByYear()
        {
            try
            {
                var output = await _db.StatsGetByYear();
                return _response.getResponse(output, "Services not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

    }
}
