using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ServicesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public string ImagePath { get; set; }
        public int UploaderID { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public UsersModel UsersModel { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
