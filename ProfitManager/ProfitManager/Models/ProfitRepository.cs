using ProfitManager.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProfitManager.Models
{
    public class ProfitRepository : IProfitRepository
    {
        private readonly DashboardContext _context;
        private readonly IProfitSaleProvider _saleProvider;
        private readonly IProfitCostProvider _costProvider;

        public ProfitRepository(DashboardContext context, IProfitSaleProvider saleProvider, IProfitCostProvider costProvider)
        {
            this._context = context;
            this._saleProvider = saleProvider;
            this._costProvider = costProvider;
        }

        /// <summary>
        /// Profits 테이블에 1년 8760시간 데이터로 초기화 
        /// </summary>
        /// <param name="parentId">부모 키 값</param>
        public void InitialProfitsByParentId(int parentId, int quantity)
        {
            // 기존 ParentId에 해당하는 모든 레코드 삭제
            _context.Profits.Where(p => p.ParentId == parentId).ToList().ForEach(p => _context.Profits.Remove(p));
            _context.SaveChanges();

            // 매출의 Order를 1부터 8760까지 순서대로 List<T>로 가져오기 
            var sales = _saleProvider.GetSales(parentId).OrderBy(s => s.Order).ToList();
            var costs = _costProvider.GetCosts(parentId).OrderBy(c => c.Order).ToList(); 

            // 특정 ParentId에 해당하는 8760개 Order 생성 
            var profits = new List<ProfitModel>();
            for (int i = 1; i <= 8760; i++)
            {
                var sale = sales[i - 1].Sale;
                var cost = costs[i - 1].Cost;
                var profit = (sale - cost) * quantity; 
                profits.Add(new ProfitModel { ParentId = parentId, Order = i, Sale = sale, Cost = cost, Quantity = quantity, Profit = profit });
            }

            _context.AddRange(profits.OrderBy(p => p.Order)); 
            _context.SaveChanges(); // 하나 Add() 후 SaveChanges() 요청하면 순서대로 입력되지만, 성능 느려짐
        }
    }
}
