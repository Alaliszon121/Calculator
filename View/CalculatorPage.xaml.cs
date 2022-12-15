using System.Diagnostics.Metrics;
using System.Reflection;

namespace Calculator.View;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();

        WriteHistory();
	}

    double result;
    double firstdigit;
    string operators;
    bool is_operator_exist = false;
    string historyRes;

    private void WriteHistory()
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        using StreamReader outputFile = new(Path.Combine(docPath, "history.txt"), true);
        string line;
        while ((line = outputFile.ReadLine()) != null)
        {
            history.Add(new Label { Text = line });
        }
    }
    private void OnNumberClicked(object sender, EventArgs e)
    {
        if (editableEquations.Text == "0" || is_operator_exist)
        {
            editableEquations.Text = "";
        }
        is_operator_exist = false;
        Button button = (Button)sender;
        if (editableEquations.Text == ".")
        {
            if (!editableEquations.Text.Contains("."))
            {
                editableEquations.Text += button.Text;
            }
        }
        else
            editableEquations.Text += button.Text;
    }

    private void ClearLastChar(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            int index = editableEquations.Text.Length;
            index--;
            editableEquations.Text = editableEquations.Text.Remove(index);
            if (editableEquations.Text == "")
            {
                editableEquations.Text = "0";
            }
        }
    }

    private void OnClear(object sender, EventArgs e)
    {
        editableEquations.Text = "0";
    }

    private void OnChangeSign(object sender, EventArgs e)
    {
        result = double.Parse(editableEquations.Text);
        result *= -1;
        results.Text = result.ToString();
    }

    private void OnSelectOperator(object sender, EventArgs e)
    {
        Button Optr = (Button)sender;
        if (editableEquations.Text != "")
        {
            firstdigit = double.Parse(editableEquations.Text);
            operators = Optr.Text;
            is_operator_exist = true;
        }
        else if (editableEquations.Text == "" && Optr.Text == "-")
        {
            editableEquations.Text = "-";
        }
    }
    private void CalculateAndSave(object sender, EventArgs e)
    {
        double secondDigit = double.Parse(editableEquations.Text);
        switch (operators)
        {
            case "+":
                results.Text = (firstdigit + secondDigit).ToString();
                break;
            case "-":
                results.Text = (firstdigit - secondDigit).ToString();
                break;
            case "*":
                results.Text = (firstdigit * secondDigit).ToString();
                break;
            case "/":
                if (secondDigit == 0)
                {
                    results.Text = "Błąd. Próba dzielenia przez 0.";
                    secondDigit = 0;
                }
                else
                    results.Text = (firstdigit / secondDigit).ToString();
                break;
            case "mod(x)":
                results.Text = (firstdigit % double.Parse(editableEquations.Text)).ToString();
                break;
        }
        historyRes = firstdigit.ToString() + " " + operators + " " + secondDigit.ToString() + " = " + results.Text;
        history.Add(new Label { Text = historyRes });
        if (operators != "/" && secondDigit != 0)
        {
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(results.Text);
        }
        else
        {
            editableEquations.Text = "0";
            firstdigit = 0;
        }
        operators = "";
        Calculator.SaveHistory(historyRes);
    }

    private void OnLog(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Log10(result);
            results.Text = result.ToString();
            historyRes = "log(" + editableEquations.Text + ") = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }

    private void OnAbsolute(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Abs(result);
            results.Text = result.ToString();
            editableEquations.Text = "|" + editableEquations.Text + "|";
            historyRes = editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }

    private void OnRoot(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Sqrt(result);
            results.Text = result.ToString();
            editableEquations.Text = "√" + editableEquations.Text;
            historyRes = "\n" + editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }

    private void OnSin(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Sin(result);
            results.Text = result.ToString();
            editableEquations.Text = "sin(" + editableEquations.Text + ")";
            historyRes = editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }

    private void OnCos(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Cos(result);
            results.Text = result.ToString();
            editableEquations.Text = "cos(" + editableEquations.Text + ")";
            historyRes = editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }

    private void OnPi(object sender, EventArgs e)
    {
        result = Math.PI;
        editableEquations.Text = result.ToString();
    }

    private void OnPower(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Pow(result, 2);
            results.Text = result.ToString();
            editableEquations.Text += "^2";
            historyRes = editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }

    private void OnDenominator(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = 1 / result;
            results.Text = result.ToString();
            editableEquations.Text = "1/" + editableEquations.Text;
            historyRes = editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }

    }

    private void OnPercentage(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result /= 100;
            results.Text = result.ToString();
            historyRes = editableEquations.Text + "/100 = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
            Calculator.SaveHistory(historyRes);
        }
    }
}