
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
    public class ModelsController : Controller
    {
        private readonly IDataService _db;
        public JsonResponses _response = new JsonResponses();

        public ModelsController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createModels")]
        public async Task<ActionResult<ModelsModel>> createModels([FromBody] ModelsModel model)
        {
            try
            {
                var output = await _db.ModelsCreate(model);
                return _response.getResponse(output, "Error while creating Models");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getModels")]
        public async Task<ActionResult<ModelsModel>> getModelsById(int id)
        {
            try
            {
                var output = await _db.ModelsGet(id);
                return _response.getResponse(output, "Models not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllModels")]
        public async Task<ActionResult<IEnumerable<ModelsModel>>> getAllModels()
        {
            try
            {
                var output = await _db.ModelsGetAll();
                return _response.getResponse(output, "Models not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateModels")]
        public async Task<ActionResult<ModelsModel>> updateModels([FromBody] ModelsModel model)
        {
            try
            {
                await _db.ModelsUpdate(model);
                return _response.getResponse("", "Models not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteModels")]
        public async Task<ActionResult<ModelsModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.ModelsDelete(id);
                return _response.getResponse("", "Models Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
