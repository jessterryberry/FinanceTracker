using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Shared
{
    public class Expense
    {
        public Expense()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public ExpenseCategory Category { get; set; }
        public decimal Amount { get; set; }

        public static void SaveToJson(List<Expense> allExpenses)
        {
            string outputJson = JsonConvert.SerializeObject(allExpenses, Formatting.Indented);
            File.WriteAllText(@"./../expenses.json", outputJson + Environment.NewLine);
        }

        public static List<Expense> LoadJson()
        {
            List<Expense> allExpenses = new List<Expense>();
            if (File.Exists(@"./../expenses.json"))
            {
                string JsonText = File.ReadAllText(@"./../expenses.json");
                allExpenses = (List<Expense>)JsonConvert.DeserializeObject<IEnumerable<Expense>>(JsonText);
            }
            return allExpenses;
        }
    }
}
