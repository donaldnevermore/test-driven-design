namespace TestDrivenDesign
{
    public class SpecificOrder
    {
        private void BadOrder()
        {
            /*
            InitializeExpenseData(expenseData);
            ComputeMarketingExpense(expenseData);
            ComputeSalesExpense(expenseData);
            ComputeTravelExpense(expenseData);
            ComputePersonnelExpense(expenseData);
            DisplayExpenseSummary(expenseData);
            */
        }

        private void GoodOrder()
        {
            /*
            expenseData = InitializeExpenseData(expenseData);
            expenseData = ComputeMarketingExpense(expenseData);
            expenseData = ComputeSalesExpense(expenseData);
            expenseData = ComputeTravelExpense(expenseData);
            expenseData = ComputePersonnelExpense(expenseData);
            DisplayExpenseSummary(expenseData);
            */
        }

        private void NoOrder()
        {
            /*
            ComputeMarketingExpense(marketingData);
            ComputeSalesExpense(salesData);
            ComputeTravelExpense(travelData);
            ComputePersonnelExpense(personnelData);
            DisplayExpenseSummary(marketingData, salesData, travelData, personnelData);
            */
        }
    }
}
