using Dashboard.Logic;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard
{
    public class DataSingleton
    {
        private static DataSingleton instance;

        public List<Transaction> Transactions { get; private set; }
        public double[] MoneyouMoney { get; private set; }
        public double[] RaboSpaarMoney { get; private set; }
        public double[] RaboBetaalMoney { get; private set; }

        private DataSingleton() {
            Transactions = ReadTransactions();
            Transactions = Transactions.OrderBy(x => x.Date).ToList();
            RaboBetaalMoney = new double[]{ 15020.12,3866.17,3064.83,3322.99, 3769.79, 3814.26, 3125.29, 3063.76,3333.03,5231.03, 5053.27, 5125.20};
            RaboSpaarMoney = new double[] { 8751.69, 6751.69, 6751.69, 6751.69, 6751.69, 6751.69, 6751.69, 6751.69, 6751.69, 6751.69, 6762.17, 6762.17};
            MoneyouMoney = new double[] {
                15325.13,
                20325.13,
                20325.13,
                20325.13,
                20325.13,
                20325.13,
                774.05,
                774.05,
                774.05,
                774.05,
                774.05,
                774.05
            };
        }

        private List<Transaction> ReadTransactions()
        {
            var tempList = new List<Transaction>();
            var reader = new TsvReader();
            var dir = Directory.GetCurrentDirectory();
            var assetPath = Path.Combine(dir, "Data");
            var files = Directory.GetFiles(assetPath);
            foreach (var file in files) {
                tempList = tempList.Concat(reader.ReadTransactions(file)).ToList();
            }
            return tempList;
        }

        public static DataSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataSingleton();
                }
                return instance;
            }
        }
    }
}
