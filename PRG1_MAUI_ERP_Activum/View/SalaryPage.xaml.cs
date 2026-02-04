using System.Globalization;

namespace PRG1_MAUI_ERP_Activum.View;

public partial class SalaryPage : ContentPage
{
	public SalaryPage()
	{
		InitializeComponent();
	}

	private void OnCalculateSalaryClicked(object sender, EventArgs e)
	{
		if (double.TryParse(SalesEntry.Text, out double sales))
		{
			double baseSalary = 26000;
			double commission = sales * 0.12;
			double grossSalary = baseSalary + commission;

			double tax = grossSalary * 0.32;
			double netSalary = grossSalary - tax;

			var swedishCulture = new CultureInfo("sv-SE");

			CommissionLabel.Text = commission.ToString("C0", swedishCulture);
			TaxLabel.Text = tax.ToString("C0", swedishCulture);
			NetSalaryLabel.Text = netSalary.ToString("C0", swedishCulture);
		}
		else
		{
			DisplayAlert("Fel", "Skriv in en siffra för försäljningen.", "OK");
		}
	}

}