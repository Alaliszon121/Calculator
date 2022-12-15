using System;
using System.Globalization;

namespace Calculator;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    double result;
    double firstdigit;
    string operators;
    bool is_operator_exist = false;
    string historyRes;
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
        result = result * -1;
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
        else if(editableEquations.Text == "" && Optr.Text == "-")
        {
            editableEquations.Text = "-";
        }
    }
    private void CalculateAndSave(object sender, EventArgs e)
    {
        switch (operators)
        {
            case "+":
                results.Text = (firstdigit + double.Parse(editableEquations.Text)).ToString();
                break;
            case "-":
                results.Text = (firstdigit - double.Parse(editableEquations.Text)).ToString();
                break;
            case "*":
                results.Text = (firstdigit * double.Parse(editableEquations.Text)).ToString();
                break;
            case "/":
                results.Text = (firstdigit / double.Parse(editableEquations.Text)).ToString();
                break;
            case "mod(x)":
                results.Text = (firstdigit % double.Parse(editableEquations.Text)).ToString();
                break;
        }
        historyRes = "\n" + firstdigit.ToString() + " " + operators + " " + 
            double.Parse(editableEquations.Text).ToString() + " = " + results.Text;
        //DisplayHistory(historyRes);
        history.Add(new Label { Text = historyRes });
        editableEquations.Text = results.Text;
        firstdigit = double.Parse(editableEquations.Text);
    }

    private void OnLog(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = Math.Log10(result);
            results.Text = result.ToString();
            historyRes = "\n" + "log(" + editableEquations.Text + ") = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
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
            historyRes = "\n" + editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
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
            historyRes = "\n" + editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
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
            historyRes = "\n" + editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
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
            editableEquations.Text = editableEquations.Text + "^2";
            historyRes = "\n" + editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
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
            historyRes = "\n" + editableEquations.Text + " = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
        }
        
    }

    private void OnPercentage(object sender, EventArgs e)
    {
        if (editableEquations.Text != "")
        {
            result = double.Parse(editableEquations.Text);
            result = result / 100;
            results.Text = result.ToString();
            historyRes = "\n" + editableEquations.Text + "/100 = " + results.Text;
            editableEquations.Text = results.Text;
            firstdigit = double.Parse(editableEquations.Text);
            history.Add(new Label { Text = historyRes });
        }
    }
}