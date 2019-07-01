using System.Collections.Generic;

namespace ProfitManager.Models
{
    public interface IProfitSaleProvider
    {
        List<ProfitModel> GetSales(int parentId);
    }
}