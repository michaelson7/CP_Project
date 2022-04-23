using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class HostRetriver : Controller
    {
        public string getHostData()
        {
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
        }
    }
}
