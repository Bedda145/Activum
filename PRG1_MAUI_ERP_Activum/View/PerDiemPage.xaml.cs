namespace PRG1_MAUI_ERP_Activum.View;

public partial class PerDiemPage : ContentPage
{
	public PerDiemPage()
	{
		InitializeComponent();
	}

	public void CalculateBtn(object sender, EventArgs args)
	{
        Button CalculateBtn = (Button)sender;

        int fullDays = 420;
		int halfDays = 210;

		string Input = Field_one.Text;
		string Input1 = Field_two.Text;
		string Input2 = Field_three.Text;




		if (double.TryParse(Input, out double number))
		{
			double result = fullDays * number;

			Result.Text = result.ToString() + " kr";
		}
		else
		{
			Console.WriteLine("Invalid input");
        }

		if(double.TryParse(Input1, out double number1))
		{
			double result1 = halfDays * number1;
			Result.Text = result1.ToString() + " kr";
		}
		else
		{
			Console.WriteLine("Invalid input");
		}
		if (double.TryParse(Input2, out double number2))
		{
			double result2 = 0 + number2;
			Result.Text = result2.ToString() + " kr";
		}
		else
		{
			Console.WriteLine("Invalid input");
		}

		if (1 > 0)
		{
			double all = fullDays * number + number1 * halfDays + number2;
			Result.Text = all.ToString() + " kr";

        }

		



    }
}