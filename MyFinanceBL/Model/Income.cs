namespace MyFinanceBL.Model
{
    public record Income(decimal Amount, DateOnly ReceivedAt, IncomeType Type, int id = 0);
}
