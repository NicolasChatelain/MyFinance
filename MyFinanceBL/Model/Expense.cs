namespace MyFinanceBL.Model
{
    public record Expense(decimal Amount, DateOnly MadeAt, ExpenseType Type, int id = 0);
}
