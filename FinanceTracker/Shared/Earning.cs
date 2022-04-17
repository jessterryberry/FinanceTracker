using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FinanceTracker.Shared
{
    public class Earning
    {
        public Earning()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public EarningCategory Category { get; set; }
        public decimal Amount { get; set; }

        public static void SaveToJson(IEnumerable<Earning> allEarnings)
        {
            string outputJson = JsonConvert.SerializeObject(allEarnings, Formatting.Indented);
            File.WriteAllText(@"./../earnings.json", outputJson + Environment.NewLine);
        }

        public static List<Earning> LoadJson()
        {
            List<Earning> allEarnings = new List<Earning>();
            if (File.Exists(@"./../earnings.json"))
            {
                string JsonText = File.ReadAllText(@"./../earnings.json");
                allEarnings = JsonConvert.DeserializeObject<List<Earning>>(JsonText);
            }
            return allEarnings;
        }
    }
}
