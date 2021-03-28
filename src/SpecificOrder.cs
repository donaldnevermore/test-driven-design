namespace TestDrivenDesign {
    public class SpecificOrder {
        public static void BadOrder() {
            var expenseData = "expenseData";
            InitializeExpenseData(expenseData);
            ComputeMarketingExpense(expenseData);
            ComputeSalesExpense(expenseData);
            ComputeTravelExpense(expenseData);
            ComputePersonnelExpense(expenseData);
            DisplayExpenseSummary(expenseData);
        }

        public static void GoodOrder() {
            var expenseData = "expenseData";
            expenseData = InitializeExpenseData(expenseData);
            expenseData = ComputeMarketingExpense(expenseData);
            expenseData = ComputeSalesExpense(expenseData);
            expenseData = ComputeTravelExpense(expenseData);
            expenseData = ComputePersonnelExpense(expenseData);
            DisplayExpenseSummary(expenseData);
        }

        public static void NoOrder() {
            var marketingData = "marketingData";
            var salesData = "salesData";
            var travelData = "travelData";
            var personnelData = "personnelData";
            ComputeMarketingExpense(marketingData);
            ComputeSalesExpense(salesData);
            ComputeTravelExpense(travelData);
            ComputePersonnelExpense(personnelData);
            DisplayExpenseSummary(marketingData, salesData, travelData, personnelData);
        }

        private static string InitializeExpenseData(string data) {
            return data;
        }
        private static string ComputeMarketingExpense(string data) {
            return data;

        }
        private static string ComputeSalesExpense(string data) {
            return data;
        }
        private static string ComputeTravelExpense(string data) {
            return data;
        }
        private static string ComputePersonnelExpense(string data) {
            return data;
        }
        private static void DisplayExpenseSummary(string a) { }
        private static void DisplayExpenseSummary(string a, string b, string c, string d) { }
    }
}
