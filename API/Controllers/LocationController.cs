using API.Services;
using Applicationn.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LocationController : Controller
    {
        private readonly IDataService _db;
        public JsonResponses _response = new JsonResponses();

        public LocationController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createLocation")]
        public async Task<ActionResult<LocationModel>> createLocation([FromBody] LocationModel model)
        {
            try
            {
                var output = await _db.LocationCreate(model);
                return _response.getResponse(output, "Error while creating Location");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getLocation")]
        public async Task<ActionResult<LocationModel>> getLocationById(int id)
        {
            try
            {
                var output = await _db.LocationGet(id);
                return _response.getResponse(output, "Location not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllLocation")]
        public async Task<ActionResult<IEnumerable<LocationModel>>> getAllLocation()
        {
            try
            {
                var output = await _db.LocationGetAll();
                return _response.getResponse(output, "Location not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateLocation")]
        public async Task<ActionResult<LocationModel>> updateLocation([FromBody] LocationModel model)
        {
            try
            {
                await _db.LocationUpdate(model);
                return _response.getResponse("", "Location not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteLocation")]
        public async Task<ActionResult<LocationModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.LocationDelete(id);
                return _response.getResponse("", "Location Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
