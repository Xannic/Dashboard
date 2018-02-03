using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string DateString {
            get
            {
                return Date.ToString("dd-MMM-yyyy");
            }
        }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
