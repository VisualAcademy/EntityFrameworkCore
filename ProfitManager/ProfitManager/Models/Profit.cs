namespace ProfitManager.Models
{
    /// <summary>
    /// 이익(Profits) 모델 클래스
    /// </summary>
    public class ProfitModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Order { get; set; }
        public double? Sale { get; set; }
        public double? Cost { get; set; }
        public int? Quantity { get; set; }
        public double? Profit { get; set; }
    }
}
