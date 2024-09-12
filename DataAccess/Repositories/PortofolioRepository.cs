using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using MyFinanceBL.Interface;
using MyFinanceBL.Model;

namespace DataAccess.Repositories
{
    public class PortofolioRepository : IPortfolioRepository
    {
        private readonly AppContext _context;

        public PortofolioRepository()
        {
            _context = new();
        }

        public async Task<bool> AddExpense(Expense expense)
        {
            ExpenseEF expenseEF = new()
            {
                Amount = expense.Amount,
                ExpenseAt = expense.MadeAt,
                Type = expense.Type,
            };

            try
            {
                await _context.Expense.AddAsync(expenseEF);
                var succes = await _context.SaveChangesAsync();

                return succes == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddIncome(Income income)
        {
            IncomeEF incomeEF = new()
            {
                Amount = income.Amount,
                EarnedAt = income.ReceivedAt,
                Type = income.Type,
            };

            try
            {
                await _context.Income.AddAsync(incomeEF);
                var succes = await _context.SaveChangesAsync();

                return succes == 1;
            }
            catch
            {
                return false;
            }
        }

        public List<Expense> GetExpenses()
        {
            List<Expense> expenses = [];

            try
            {
                expenses = _context.Expense.AsNoTracking().Select(x => new Expense(x.Amount, x.ExpenseAt, x.Type)).ToList();
            }
            catch
            {
                // TODO
            }

            return expenses;
        }

        public List<Income> GetIncome()
        {
            List<Income> incomes = [];

            try
            {
                incomes = _context.Income.AsNoTracking().Select(x => new Income(x.Amount, x.EarnedAt, x.Type)).ToList();
            }
            catch
            {
                // TODO
            }

            return incomes;
        }
    }
}
