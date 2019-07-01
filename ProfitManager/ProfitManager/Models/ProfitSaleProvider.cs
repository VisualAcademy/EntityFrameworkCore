using System.Collections.Generic;

namespace ProfitManager.Models
{
    public class ProfitSaleProvider : IProfitSaleProvider
    {
        public List<ProfitModel> GetSales(int parentId)
        {
            List<ProfitModel> r = new List<ProfitModel>();

            // 8760개를 임시로: 실제는 데이터베이스에서 가져옴
            int j = 8760;
            for (int i = 0; i < 8760; i++)
            {
                r.Add(new ProfitModel { ParentId = parentId, Order = i + 1, Sale = j-- });
            }

            return r;
        }
    }
}
