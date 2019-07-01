using Microsoft.EntityFrameworkCore;
using ProfitManager.Models;

namespace ProfitManager.Data
{
    public class DashboardContext : DbContext
    {
        /// <summary>
        /// Profits 테이블 참조
        /// </summary>
        public DbSet<ProfitModel> Profits { get; set; }

        /// <summary>
        /// 생성자 매개변수에 옵션값 전달
        /// </summary>
        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        {

        }
    }
}
