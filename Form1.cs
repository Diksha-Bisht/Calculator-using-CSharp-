using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcultor
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String Operationperformed = "";
        bool isoperatonperformed = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void View_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_click(object sender, EventArgs e)
        {
            if ((View.Text == "0") || (isoperatonperformed))
                View.Clear();

            isoperatonperformed = false;

            Button button = (Button)sender;
            if(button.Text==".")
            {
                if (!View.Text.Contains("."))
                    View.Text += button.Text;
            }
            else
                View.Text += button.Text;
             
        }

        private void Operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                Equal.PerformClick();
                Operationperformed = button.Text;
                isoperatonperformed = true;
                currentoperation.Text = resultValue + " " + Operationperformed;
            }


            else
            {
                Operationperformed = button.Text;
                resultValue = double.Parse(View.Text);
                isoperatonperformed = true;
                currentoperation.Text = resultValue + " " + Operationperformed;
            }
            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            View.Text = "0";
            resultValue = 0;
            currentoperation.Text = "";
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            switch(Operationperformed)
            {
                case "+":
                    View.Text = (resultValue + Double.Parse(View.Text)).ToString();
                    break;

                case "-":
                    View.Text = (resultValue - Double.Parse(View.Text)).ToString();
                    break;

                case "*":
                    View.Text = (resultValue * Double.Parse(View.Text)).ToString();
                    break;

                case "/":
                    View.Text = (resultValue / Double.Parse(View.Text)).ToString();
                    break;

                case "%":
                    View.Text = (resultValue/100 * Double.Parse(View.Text)).ToString();
                    break;

                case "^2":
                    View.Text = (resultValue * resultValue).ToString();
                    break;

                case "^1/2":
                    View.Text = Math.Sqrt( resultValue).ToString();
                    break;

                case "1/x":
                    View.Text = (1 / resultValue).ToString();
                    break;

                case "-x":
                    View.Text = (-1 * resultValue).ToString();
                    break;

                default:
                    break;
            }
            resultValue= Double.Parse(View.Text);
            currentoperation.Text = "";
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Operationperformed = button.Text;
            View.Text = (int.Parse(View.Text)/ 10).ToString();
            resultValue = Double.Parse(View.Text);
            isoperatonperformed = false;
        }

        private void Inverse_Click_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Operationperformed = button.Text;
            currentoperation.Text = "1/ " + View.Text;
            resultValue = Double.Parse(View.Text);
            isoperatonperformed = false;
        }

        private void Nor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Operationperformed = button.Text;
            currentoperation.Text = (-1 * int.Parse(View.Text)).ToString() ;
            resultValue = Double.Parse(View.Text);
            isoperatonperformed = false;
        }
    }
}
