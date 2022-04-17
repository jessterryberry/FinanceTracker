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
    public class EarningsController : ControllerBase
    {
        private readonly IRepository<Earning> _earningRepository;
        public EarningsController(IRepository<Earning> earningRepository)
        {
            _earningRepository = earningRepository;
        }
        [HttpGet]
        public IEnumerable<Earning> Get()
        {
            return _earningRepository.GetAll()
                .OrderBy(earning => earning.Date);
        }

        [HttpPost]
        public void Post(Earning earning)
        {
            List<Earning> earnings = Earning.LoadJson();
            earnings.Add(earning);
            Earning.SaveToJson(earnings);

            _earningRepository.Add(earning);
        }

        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            List<Earning> earnings = Earning.LoadJson();
            earnings.Remove(earnings
                .Where(e => e.Id == id)
                .FirstOrDefault());
            Earning.SaveToJson(earnings);

            var entity = _earningRepository.GetAll()
              .Single(item => item.Id == id);
            _earningRepository.Remove(entity);
        }

    }
}
