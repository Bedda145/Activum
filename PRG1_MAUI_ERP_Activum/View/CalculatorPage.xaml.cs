using System.Globalization;

namespace PRG1_MAUI_ERP_Activum.View.CalculatorPage;

public partial class MainPage : ContentPage
{
    double storedValue = 0;
    string currentOperator = "";
    bool isNewEntry = true;

    public CalculatorPage()
    {
        InitializeComponent();
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        Button pressedButton = sender as Button;
        string buttonText = pressedButton.Text;

        if (buttonText == "C")
        {
            ClearAll();
        }
        else if (buttonText == "⌫")
        {
            Backspace();
        }
        else if (buttonText == "=")
        {
            Calculate();
        }
        else if (buttonText == "±")
        {
            ToggleSign();
        }
        else if (buttonText == "%")
        {
            Percentage();
        }
        else
        {

            if (buttonText == "+")
            {
                ProcessOperator(buttonText);
            }
            else if (buttonText == "-")
            {
                ProcessOperator(buttonText);
            }
            else if (buttonText == "x")
            {
                ProcessOperator(buttonText);
            }
            else if (buttonText == "÷")
            {
                ProcessOperator(buttonText);
            }
            else
            {
                ProcessDigit(buttonText);
            }
        }
    }

    void ProcessDigit(string digit)
    {
        if (isNewEntry)
        {
            DisplayEntry.Text = digit;
            isNewEntry = false;
        }
        else
        {
            if (DisplayEntry.Text == "0")
            {
                DisplayEntry.Text = digit;
            }
            else
            {
                DisplayEntry.Text = DisplayEntry.Text + digit;
            }
        }
    }

    void ProcessOperator(string op)
    {
        try
        {
            double currentValue = double.Parse(DisplayEntry.Text, CultureInfo.InvariantCulture);
            if (currentOperator != "")
            {
                storedValue = PerformCalculation(storedValue, currentValue, currentOperator);
                DisplayEntry.Text = storedValue.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                storedValue = currentValue;
            }
            currentOperator = op;
            isNewEntry = true;
        }
        catch
        {
            DisplayEntry.Text = "Error";
        }
    }

    void Calculate()
    {
        try
        {
            if (currentOperator == "")
            {
                return;
            }
            double currentValue = double.Parse(DisplayEntry.Text, CultureInfo.InvariantCulture);
            double result = PerformCalculation(storedValue, currentValue, currentOperator);
            DisplayEntry.Text = result.ToString(CultureInfo.InvariantCulture);
            storedValue = result;
            currentOperator = "";
            isNewEntry = true;
        }
        catch
        {
            DisplayEntry.Text = "Error";
        }
    }

    double PerformCalculation(double a, double b, string op)
    {
        if (op == "+")
        {
            return a + b;
        }
        if (op == "-")
        {
            return a - b;
        }
        if (op == "x")
        {
            return a * b;
        }
        if (op == "÷")
        {
            return a / b;
        }
        return b;
    }

    void ClearAll()
    {
        DisplayEntry.Text = "0";
        storedValue = 0;
        currentOperator = "";
        isNewEntry = true;
    }

    void Backspace()
    {
        if (isNewEntry == false)
        {
            if (DisplayEntry.Text.Length > 0)
            {
                DisplayEntry.Text = DisplayEntry.Text.Substring(0, DisplayEntry.Text.Length - 1);
                if (DisplayEntry.Text == "")
                {
                    DisplayEntry.Text = "0";
                    isNewEntry = true;
                }
            }
        }
    }

    void ToggleSign()
    {
        try
        {
            double currentValue = double.Parse(DisplayEntry.Text, CultureInfo.InvariantCulture);
            currentValue = -currentValue;
            DisplayEntry.Text = currentValue.ToString(CultureInfo.InvariantCulture);
        }
        catch
        {

        }
    }

    void Percentage()
    {
        try
        {
            double currentValue = double.Parse(DisplayEntry.Text, CultureInfo.InvariantCulture);
            currentValue = currentValue / 100;
            DisplayEntry.Text = currentValue.ToString(CultureInfo.InvariantCulture);
        }
        catch
        {

        }
    }
}
}
