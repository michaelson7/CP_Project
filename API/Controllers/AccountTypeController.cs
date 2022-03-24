using API.Services;
using Applicationn.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountTypeController : Controller
    {
        private readonly IDataService _db;
        public JsonResponses _response = new JsonResponses();

        public AccountTypeController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createAccountType")]
        public async Task<ActionResult<AccountTypeModel>> createAccountType([FromBody] AccountTypeModel model)
        {
            try
            {
                var output = await _db.AccountTypeCreate(model);
                return _response.getResponse(output, "Error while creating AccountType");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getAccountType")]
        public async Task<ActionResult<AccountTypeModel>> getAccountTypeById(int id)
        {
            try
            {
                var output = await _db.AccountTypeGet(id);
                return _response.getResponse(output, "AccountType not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllAccountType")]
        public async Task<ActionResult<IEnumerable<AccountTypeModel>>> getAllAccountType()
        {
            try
            {
                var output = await _db.AccountTypeGetAll();
                return _response.getResponse(output, "AccountType not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateAccountType")]
        public async Task<ActionResult<AccountTypeModel>> updateAccountType([FromBody] AccountTypeModel model)
        {
            try
            {
                await _db.AccountTypeUpdate(model);
                return _response.getResponse("", "AccountType not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteAccountType")]
        public async Task<ActionResult<AccountTypeModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.AccountTypeDelete(id);
                return _response.getResponse("", "AccountType Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
