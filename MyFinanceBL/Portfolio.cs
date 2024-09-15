using MyFinanceBL.Interface;
using MyFinanceBL.Model;

namespace MyFinanceBL
{
    public class Portfolio
    {
        private readonly IPortfolioRepository _portfolioRepository;

        private List<Income> _incomes = [];
        private List<Expense> _expenses = [];

        public Dictionary<ExpenseType, decimal> ExpenseWithTypes = [];
        public Dictionary<IncomeType, decimal> IncomeWithTypes = [];


        public Portfolio(IPortfolioRepository ipr)
        {
            _portfolioRepository = ipr;
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            try
            {
                _expenses = _portfolioRepository.GetExpenses();
                _incomes = _portfolioRepository.GetIncome();

                CalculateChartData();
                CalculateIncomeChartData();
            }
            catch
            {
                Console.WriteLine("databaz");
            }
        }

        public async Task<bool> AddIncome(string amount, string type, DateTime date)
        {
            try
            {
                decimal ParsedAmount = decimal.Parse(amount);
                IncomeType etype = Enum.Parse<IncomeType>(type);
                DateOnly IncomeDate = DateOnly.FromDateTime(date);

                Income income = new(Math.Abs(ParsedAmount), IncomeDate, etype);

                bool succes = await _portfolioRepository.AddIncome(income);

                if (succes)
                {
                    _incomes.Add(income);
                    CalculateIncomeChartData();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddExpense(string amount, string type, DateTime date)
        {
            try
            {
                decimal ParsedAmount = decimal.Parse(amount);
                ExpenseType Etype = Enum.Parse<ExpenseType>(type);
                DateOnly ExpenseDate = DateOnly.FromDateTime(date);


                Expense expense = new(Math.Abs(ParsedAmount), ExpenseDate, Etype);

                bool succes = await _portfolioRepository.AddExpense(expense);

                if (succes)
                {
                    _expenses.Add(expense);
                    CalculateChartData();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public void CalculateChartData()
        {
            ExpenseWithTypes.Clear();

            foreach (var group in _expenses.GroupBy(exp => exp.Type))
            {
                if (ExpenseWithTypes.ContainsKey(group.Key))
                {
                    ExpenseWithTypes[group.Key] += group.Sum(x => x.Amount);
                }
                else
                {
                    ExpenseWithTypes.Add(group.Key, group.Sum(x => x.Amount));
                }
            }
        }

        public void CalculateIncomeChartData()
        {
            IncomeWithTypes.Clear();

            foreach (var group in _incomes.GroupBy(exp => exp.Type))
            {
                if (IncomeWithTypes.ContainsKey(group.Key))
                {
                    IncomeWithTypes[group.Key] += group.Sum(x => x.Amount);
                }
                else
                {
                    IncomeWithTypes.Add(group.Key, group.Sum(x => x.Amount));
                }
            }
        }

        public List<Expense> GetExpenses()
        {
            return _expenses;
        }

        public List<Income> GetIncomes()
        {
            return _incomes;
        }
    }
}
