using API.Services;
using Applicationn.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IDataService _db;
        public JsonResponses _response = new JsonResponses();

        public ServicesController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createServices")]
        public async Task<ActionResult<ServicesModel>> createServices([FromBody] ServicesModel model)
        {
            try
            {
                var output = await _db.ServicesCreate(model);
                return _response.getResponse(output, "Error while creating Services");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getServices")]
        public async Task<ActionResult<ServicesModel>> getServicesById(int id)
        {
            try
            {
                var output = await _db.ServicesGet(id);
                return _response.getResponse(output, "Services not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllServices")]
        public async Task<ActionResult<IEnumerable<ServicesModel>>> getAllServices()
        {
            try
            {
                var output = await _db.ServicesGetAll();
                return _response.getResponse(output, "Services not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateServices")]
        public async Task<ActionResult<ServicesModel>> updateServices([FromBody] ServicesModel model)
        {
            try
            {
                await _db.ServicesUpdate(model);
                return _response.getResponse("", "Services not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteServices")]
        public async Task<ActionResult<ServicesModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.ServicesDelete(id);
                return _response.getResponse("", "Services Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
