using API.Services;
using Applicationn.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IDataService _db;
        public JsonResponses _response = new JsonResponses();

        public BookingsController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createBookings")]
        public async Task<ActionResult<BookingsModel>> createBookings([FromBody] BookingsModel model)
        {
            try
            {
                if (model != null)
                {
                    var output = await _db.BookingsCreate(model);
                    return _response.getResponse(output, "Error while creating Bookings");
                }
                else
                {
                    return _response.errorResponse("Invalid Model");
                }

            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getBookings")]
        public async Task<ActionResult<BookingsModel>> getBookingsById(int id)
        {
            try
            {
                var output = await _db.BookingsGet(id);
                return _response.getResponse(output, "Bookings not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllBookings")]
        public async Task<ActionResult<IEnumerable<BookingsModel>>> getAllBookings()
        {
            try
            {
                var output = await _db.BookingsGetAll();
                return _response.getResponse(output, "Bookings not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateBookings")]
        public async Task<ActionResult<BookingsModel>> updateBookings([FromBody] BookingsModel model)
        {
            try
            {
                await _db.BookingsUpdate(model);
                return _response.getResponse("", "Bookings not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteBookings")]
        public async Task<ActionResult<BookingsModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.BookingsDelete(id);
                return _response.getResponse("", "Bookings Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
