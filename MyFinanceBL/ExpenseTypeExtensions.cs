namespace MyFinanceBL
{
    public static class ExpenseTypeExtensions
    {
        private static readonly Dictionary<ExpenseType, string> ColorMap = new()
        {
            { ExpenseType.Sustenance, "#FF0000" },     // Red
            { ExpenseType.Fuel, "#00FF00" },           // Green
            { ExpenseType.Sport, "#0000FF" },          // Blue
            { ExpenseType.Insurance, "#FFFF00" },      // Yellow
            { ExpenseType.Transportation, "#FF00FF" }, // Magenta
            { ExpenseType.Utilities, "#00FFFF" },      // Cyan
            { ExpenseType.Entertainment, "#800080" },  // Purple
            { ExpenseType.Healthcare, "#FFA500" },     // Orange
            { ExpenseType.Education, "#008000" },      // Dark Green
            { ExpenseType.Rent, "#FFC0CB" },           // Pink
            { ExpenseType.Mortgage, "#A52A2A" },       // Brown
            { ExpenseType.Maintenance, "#808080" },    // Gray
            { ExpenseType.Clothing, "#FFD700" },       // Gold
            { ExpenseType.Taxes, "#000080" },          // Navy
            { ExpenseType.Travel, "#40E0D0" },         // Turquoise
            { ExpenseType.Savings, "#7FFF00" },        // Chartreuse
            { ExpenseType.Gifts, "#FF69B4" },          // Hot Pink
            { ExpenseType.Donations, "#4B0082" }       // Indigo
        };

        public static string GetColor(this ExpenseType et)
        {
            return ColorMap[et];
        }
    }
}
