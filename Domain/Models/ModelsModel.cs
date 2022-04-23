using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ModelsModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
    }
}
