using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class TransactionStats
    {
        public int BookingsCount { get; set; }
        public int UserCount { get; set; }
        public int ServiceCount { get; set; }
        public double TransactionValue { get; set; }

    }
}
