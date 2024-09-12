using MyFinanceBL;

namespace DataAccess.Entity
{
    public class IncomeEF
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly EarnedAt { get; set; }
        public IncomeType Type { get; set; }
    }
}
