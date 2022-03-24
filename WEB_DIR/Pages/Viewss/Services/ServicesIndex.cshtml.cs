using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Applicationn.Interfaces;
using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_DIR.Services;

namespace WEB_DIR.Pages.Viewss.Services
{
    public class ServicesIndexModel : PageModel
    {
        private readonly IDataService _db;
        private readonly IWebHostEnvironment _env;

        public ImageHandler _imageHandler = new ImageHandler();
        public List<ServicesModel> ServicesModel = new List<ServicesModel>();

        [BindProperty(SupportsGet = true)]
        public bool hasError { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public bool hasResponse { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public string errorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public DbOperations dbOperation { get; set; }

        public ServicesIndexModel(IDataService db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task OnGetAsync()
        {
            //get all  
            ServicesModel = await _db.ServicesGetAll();
        }

        public async Task<IActionResult> OnPost(ServicesModel model, DbOperations dbOperations, int deleteId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            //update image if present
            var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
            if (imageName != null)
            {
                model.ImagePath = imageName;
            }

            model.UploaderID = int.Parse(Request.Cookies["userId"]); 
            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Create:
                        var id = await _db.ServicesCreate(model);
                        break;
                    case DbOperations.Update:
                        await _db.ServicesUpdate(model);
                        break;
                    case DbOperations.Delete:
                        await _db.ServicesDelete(deleteId);
                        break;
                }
                return RedirectToPage(new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage(new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }


    }
}
