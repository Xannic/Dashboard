using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class ViewModel
    {
        public double[] RaboBetaal { get; set; }
        public double[] RaboSpaar { get; set; }
        public double[] Moneyou { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
