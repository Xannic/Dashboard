using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;

namespace Dashboard.Logic
{
    public class TsvReader
    {
        internal IEnumerable<Transaction> ReadTransactions(string file)
        {
            var transactions = new List<Transaction>();
            using (var reader = new StreamReader(file))
            {
                string currentLine;
                reader.ReadLine();
                while ((currentLine = reader.ReadLine()) != null)
                {
                    currentLine = currentLine.ToLower();
                    var values = currentLine.Split('\t');

                    transactions.Add(ValuesToTransaction(values));
                }
            }
            return transactions;
        }

        private Transaction ValuesToTransaction(string[] values)
        {
            return new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.ParseExact(values[0],"dd-MM-yyyy", CultureInfo.InvariantCulture),
                Debit = (string.IsNullOrWhiteSpace(values[1])) ? 0 : double.Parse(values[1]),
                Credit = (string.IsNullOrWhiteSpace(values[2])) ? 0 : double.Parse(values[2]),
                Category = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(values[3].ToLower()),
                Description = values[4]
            };
        }
    }
}
