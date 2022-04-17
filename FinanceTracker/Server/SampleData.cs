using FinanceTracker.Server.Storage;
using FinanceTracker.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Server
{
    public static class SampleData
    {
        public static void AddEarningsRepository(this IServiceCollection services)
        {
            var today = DateTime.Today;
            var lastMonth = DateTime.Today.AddMonths(-1);
            var previousMonth = DateTime.Today.AddMonths(-2);
            var earningRepository = new MemoryRepository<Earning>();
            if (Earning.LoadJson().Count == 0)
            {
                earningRepository.Add(new Earning { Date = new DateTime(previousMonth.Year, previousMonth.Month, 25), Amount = 2480, Category = EarningCategory.Salary, Subject = "Monthly Salary" });
                earningRepository.Add(new Earning { Date = new DateTime(previousMonth.Year, previousMonth.Month, 12), Amount = 440, Category = EarningCategory.Business, Subject = "Freelancing Client A" });
                earningRepository.Add(new Earning { Date = new DateTime(lastMonth.Year, lastMonth.Month, 25), Amount = 2480, Category = EarningCategory.Salary, Subject = "Monthly Salary" });
                earningRepository.Add(new Earning { Date = new DateTime(lastMonth.Year, lastMonth.Month, 12), Amount = 790, Category = EarningCategory.Business, Subject = "Freelancing Client A" });
                earningRepository.Add(new Earning { Date = new DateTime(lastMonth.Year, lastMonth.Month, 4), Amount = 387, Category = EarningCategory.Interests, Subject = "ETF Dividends" });
                earningRepository.Add(new Earning { Date = new DateTime(today.Year, today.Month, 25), Amount = 2480, Category = EarningCategory.Salary, Subject = "Monthly Salary" });
                earningRepository.Add(new Earning { Date = new DateTime(today.Year, today.Month, 14), Amount = 680, Category = EarningCategory.Business, Subject = "Freelancing Client A" });
                earningRepository.Add(new Earning { Date = new DateTime(today.Year, today.Month, 12), Amount = 245, Category = EarningCategory.ExtraIncome, Subject = "Old TV" });

                List<Earning> earnings = new List<Earning>();

                earnings.Add(new Earning { Date = new DateTime(previousMonth.Year, previousMonth.Month, 25), Amount = 2480, Category = EarningCategory.Salary, Subject = "Monthly Salary" });
                earnings.Add(new Earning { Date = new DateTime(previousMonth.Year, previousMonth.Month, 12), Amount = 440, Category = EarningCategory.Business, Subject = "Freelancing Client A" });
                earnings.Add(new Earning { Date = new DateTime(lastMonth.Year, lastMonth.Month, 25), Amount = 2480, Category = EarningCategory.Salary, Subject = "Monthly Salary" });
                earnings.Add(new Earning { Date = new DateTime(lastMonth.Year, lastMonth.Month, 12), Amount = 790, Category = EarningCategory.Business, Subject = "Freelancing Client A" });
                earnings.Add(new Earning { Date = new DateTime(lastMonth.Year, lastMonth.Month, 4), Amount = 387, Category = EarningCategory.Interests, Subject = "ETF Dividends" });
                earnings.Add(new Earning { Date = new DateTime(today.Year, today.Month, 25), Amount = 2480, Category = EarningCategory.Salary, Subject = "Monthly Salary" });
                earnings.Add(new Earning { Date = new DateTime(today.Year, today.Month, 14), Amount = 680, Category = EarningCategory.Business, Subject = "Freelancing Client A" });
                earnings.Add(new Earning { Date = new DateTime(today.Year, today.Month, 12), Amount = 245, Category = EarningCategory.ExtraIncome, Subject = "Old TV" });

                Earning.SaveToJson(earnings);
            }
            else
            {
                List<Earning> earnings = Earning.LoadJson();

                foreach (Earning e in earnings)
                {
                    earningRepository.Add(e);
                }
            }
            services.AddSingleton<IRepository<Earning>>(earningRepository);
        }

        public static void AddExpensesRepository(this IServiceCollection services)
        {
            var today = DateTime.Today;
            var lastMonth = DateTime.Today.AddMonths(-1);
            var previousMonth = DateTime.Today.AddMonths(-2);
            var expenseRepository = new MemoryRepository<Expense>();
            if (Expense.LoadJson().Count == 0)
            {
                expenseRepository.Add(new Expense { Date = new DateTime(previousMonth.Year, previousMonth.Month, 25), Amount = 2500, Category = ExpenseCategory.Mortgage, Subject = "Monthly Mortgage" });
                expenseRepository.Add(new Expense { Date = new DateTime(previousMonth.Year, previousMonth.Month, 12), Amount = 77.80M, Category = ExpenseCategory.Bills, Subject = "Electricity" });
                expenseRepository.Add(new Expense { Date = new DateTime(lastMonth.Year, lastMonth.Month, 25), Amount = 126.31M, Category = ExpenseCategory.Bills, Subject = "Cell Phone" });
                expenseRepository.Add(new Expense { Date = new DateTime(lastMonth.Year, lastMonth.Month, 12), Amount = 157, Category = ExpenseCategory.Insurance, Subject = "Car/Homeowner Insurance" });
                expenseRepository.Add(new Expense { Date = new DateTime(lastMonth.Year, lastMonth.Month, 4), Amount = 145, Category = ExpenseCategory.Bills, Subject = "Credit Card Bill" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 25), Amount = 201.13M, Category = ExpenseCategory.Bills, Subject = "Internet/TV" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 14), Amount = 50, Category = ExpenseCategory.Clothing, Subject = "Monthly Laundry" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 28), Amount = 125, Category = ExpenseCategory.Shopping, Subject = "Groceries" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 12), Amount = 43.72M, Category = ExpenseCategory.Healthcare, Subject = "Medication" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 19), Amount = 15, Category = ExpenseCategory.Miscellaneous, Subject = "Donation" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 4), Amount = 50.45M, Category = ExpenseCategory.Transportation, Subject = "Gas" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 29), Amount = 25.99M, Category = ExpenseCategory.Entertainment, Subject = "Video Games" });
                expenseRepository.Add(new Expense { Date = new DateTime(today.Year, today.Month, 17), Amount = 34.92M, Category = ExpenseCategory.PersonalCare, Subject = "Hair Cut" });

                List<Expense> expenses = new List<Expense>();

                expenses.Add(new Expense { Date = new DateTime(previousMonth.Year, previousMonth.Month, 25), Amount = 2500, Category = ExpenseCategory.Mortgage, Subject = "Monthly Mortgage" });
                expenses.Add(new Expense { Date = new DateTime(previousMonth.Year, previousMonth.Month, 12), Amount = 77.80M, Category = ExpenseCategory.Bills, Subject = "Electricity" });
                expenses.Add(new Expense { Date = new DateTime(lastMonth.Year, lastMonth.Month, 25), Amount = 126.31M, Category = ExpenseCategory.Bills, Subject = "Cell Phone" });
                expenses.Add(new Expense { Date = new DateTime(lastMonth.Year, lastMonth.Month, 12), Amount = 157, Category = ExpenseCategory.Insurance, Subject = "Car/Homeowner Insurance" });
                expenses.Add(new Expense { Date = new DateTime(lastMonth.Year, lastMonth.Month, 4), Amount = 145, Category = ExpenseCategory.Bills, Subject = "Credit Card Bill" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 25), Amount = 201.13M, Category = ExpenseCategory.Bills, Subject = "Internet/TV" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 14), Amount = 50, Category = ExpenseCategory.Clothing, Subject = "Monthly Laundry" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 28), Amount = 125, Category = ExpenseCategory.Shopping, Subject = "Groceries" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 12), Amount = 43.72M, Category = ExpenseCategory.Healthcare, Subject = "Medication" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 19), Amount = 15, Category = ExpenseCategory.Miscellaneous, Subject = "Donation" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 4), Amount = 50.45M, Category = ExpenseCategory.Transportation, Subject = "Gas" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 29), Amount = 25.99M, Category = ExpenseCategory.Entertainment, Subject = "Video Games" });
                expenses.Add(new Expense { Date = new DateTime(today.Year, today.Month, 17), Amount = 34.92M, Category = ExpenseCategory.PersonalCare, Subject = "Hair Cut" });

                Expense.SaveToJson(expenses);
            }
            else
            {
                List<Expense> expenses = Expense.LoadJson();

                foreach (Expense x in expenses)
                {
                    expenseRepository.Add(x);
                }
            }
            services.AddSingleton<IRepository<Expense>>(expenseRepository);
        }
    }
}
