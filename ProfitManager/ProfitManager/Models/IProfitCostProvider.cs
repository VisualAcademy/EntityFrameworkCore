using System.Collections.Generic;

namespace ProfitManager.Models
{
    public interface IProfitCostProvider
    {
        List<ProfitModel> GetCosts(int parentId);
    }
}