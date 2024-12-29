using MyFinanceBL.Model;

namespace MyFinanceBL.Interface
{
    public interface IPortfolioRepository
    {
        List<Income> GetIncome();
        List<Expense> GetExpenses();
        Task<bool> AddExpense(Expense expense);
        Task<bool> AddIncome(Income income);
    }
}
