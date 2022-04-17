using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Client.Services
{
    interface IDataService
    {
        Task<ICollection<YearlyItem>> LoadCurrentYearExpenses();
        Task<ICollection<YearlyItem>> LoadCurrentYearEarnings();
        Task<ThreeMonthsData> LoadLast3MonthsExpenses();
        Task<ThreeMonthsData> LoadLast3MonthsEarnings();
        Task<SummaryData> LoadTotalEarnings();
        Task<SummaryData> LoadTotalExpenses();
        Task<SummaryData> CalculateBalance();
    }
}
