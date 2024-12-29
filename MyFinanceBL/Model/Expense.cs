namespace MyFinanceBL.Model
{
    public class Expense(decimal amount, DateOnly madeat, ExpenseType type, int id = 0)
    {
        public int Id { get; set; } = id;
        public decimal Amount { get; set; } = amount;
        public DateOnly MadeAt { get; set; } = madeat;
        public ExpenseType Type { get; set; } = type;
    }
}
