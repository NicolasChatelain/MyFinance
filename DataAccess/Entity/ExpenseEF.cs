using MyFinanceBL;

namespace DataAccess.Entity
{
    public class ExpenseEF
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly ExpenseAt {  get; set; }
        public ExpenseType Type { get; set; }
    }
}
