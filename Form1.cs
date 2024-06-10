using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Calci
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // In this for all buttons we have given the same name 
        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || isOperationPerformed)
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text += button.Text;
            }
            else
            {
                textBox1.Text += button.Text;
            }

            // Append the clicked number to the label
            labelCurrentOperation.Text += button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                button16.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox1.Text); // Converts the retrieved text into a double (a floating-point number).
                labelCurrentOperation.Text += " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            labelCurrentOperation.Text = ""; // Clear the label as well
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = ""; // Clear the label as well
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "-":
                        textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "*":
                        textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "/":
                        double divisor = Double.Parse(textBox1.Text);
                        if (divisor != 0)
                        {
                            textBox1.Text = (resultValue / divisor).ToString();
                        }
                        else
                        {
                            textBox1.Text = "Infinity"; // Handle division by zero
                        }
                        break;
                    default:
                        break;
                }

                
                labelCurrentOperation.Text += " = ";
                resultValue = double.Parse(textBox1.Text);
                operationPerformed = ""; 
            }
            catch (FormatException)
            {
                textBox1.Text = "Infinity";
            }
            catch (Exception ex)
            {
                textBox1.Text = "Infinity";
               
            }
        }

        // Other methods...
    }
}