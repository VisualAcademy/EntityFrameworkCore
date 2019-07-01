namespace ProfitManager.Models
{
    public interface IProfitRepository
    {
        void InitialProfitsByParentId(int parentId, int quantity);
    }
}