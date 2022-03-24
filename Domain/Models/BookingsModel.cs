using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BookingsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public ServicesModel ServicesModel { get; set; }
        public UsersModel UsersModel { get; set; }
    }
}
