using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace calculator
{
    public partial class Form1 : Form
    {
        private decimal valueFirst = 0;
        private decimal valueSecond = 0;
        private decimal resualt = 0;
        private string operators = "+";

        // Mouse Tap Controller
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Form1()
        {
            InitializeComponent();

            foreach (var item in numberBox.Controls)
            {
                if (item is Button bt)
                {
                    bt.BackColor = Color.FromArgb(255, 166, 48);
                }
            }
            foreach (var item in this.Controls)
            {
                if (item is Button bt)
                {
                    bt.BackColor = Color.FromArgb(255, 166, 48);
                }
            }


            Color newColor = Color.FromArgb(66, 62, 55);
            this.BackColor = newColor;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text += 1;
            }
        }

        private void fourBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += 4;
            }
        }

        private void zeroBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += 0;
            }
        }

        private void twoBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += 2;
            }
        }

        private void threeBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += 3;
            }
        }

        private void fiveBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += 5;
            }
        }

        private void sixBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += 6;
            }
        }

        private void sevenBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += 7;
            }
        }

        private void eightBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += 8;
            }
        }

        private void nineBtr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += 9;
            }
        }

        private void plusBtr_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(textBox1.Text);
            textBox1.Clear();
            operators = "+";
        }

        private void menfiBtr_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(textBox1.Text);
            textBox1.Clear();
            operators = "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(textBox1.Text);
            textBox1.Clear();
            operators = "*";
        }

        private void bolmeBtr_Click(object sender, EventArgs e)
        {
            valueFirst = decimal.Parse(textBox1.Text);
            textBox1.Clear();
            operators = "/";
        }

        private void beraberBtr_Click(object sender, EventArgs e)
        {
            switch (operators)
            {
                case "+":
                    valueSecond = decimal.Parse(textBox1.Text);
                    resualt = valueFirst + valueSecond;
                    textBox1.Text = resualt.ToString();
                    break;
                case "-":
                    valueSecond = decimal.Parse(textBox1.Text);
                    resualt = valueFirst - valueSecond;
                    textBox1.Text = resualt.ToString();
                    break;
                case "*":
                    valueSecond = decimal.Parse(textBox1.Text);
                    resualt = valueFirst * valueSecond;
                    textBox1.Text = resualt.ToString();
                    break;
                case "/":
                    valueSecond = decimal.Parse(textBox1.Text);
                    if(valueSecond != 0)
                    {
                        resualt = valueFirst / valueSecond;
                        textBox1.Text = resualt.ToString();
                    }
                    else
                    {
                        MessageBox.Show("We cannot divide by zero !", "Zero ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
        }

        private void clearBtr_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resualt = 0;
            valueFirst = 0;
            valueSecond = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the program?", "Exiting", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private bool isFullScreen = false;

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (isFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                isFullScreen = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }
        }
    }
}
