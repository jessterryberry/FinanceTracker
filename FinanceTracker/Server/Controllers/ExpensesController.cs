using FinanceTracker.Server.Storage;
using FinanceTracker.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IRepository<Expense> _expenseRepository;
        public ExpensesController(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expenseRepository.GetAll()
                .OrderBy(expense => expense.Date);
        }

        [HttpPost]
        public void Post(Expense expense)
        {
            List<Expense> expenses = Expense.LoadJson();
            expenses.Add(expense);
            Expense.SaveToJson(expenses);

            _expenseRepository.Add(expense);
        }

        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            List<Expense> expenses = Expense.LoadJson();
            expenses.Remove(expenses
                .Where(x => x.Id == id)
                .FirstOrDefault());
            Expense.SaveToJson(expenses);

            var entity = _expenseRepository.GetAll()
              .Single(item => item.Id == id);
            _expenseRepository.Remove(entity);
        }

    }
}
