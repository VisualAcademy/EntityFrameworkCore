using Microsoft.AspNetCore.Mvc;
using ProfitManager.Data;
using ProfitManager.Models;
using System.Linq;

namespace ProfitManager.Controllers
{
    public class ProfitManagerTestController : Controller
    {
        private readonly DashboardContext _context;
        private readonly IProfitRepository _repository;

        public ProfitManagerTestController(DashboardContext context, IProfitRepository repository)
        {
            _context = context;
            this._repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var profits = _context.Profits.Take(100).ToList();
            return View(profits);
        }

        public IActionResult InitialData()
        {
            _repository.InitialProfitsByParentId(1234, 2); 

            return View(); 
        }
    }
}
