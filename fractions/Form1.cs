using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractions
{
    public struct fraction
    {

        public int numerator;
        public int denominator;
        public int newnum;
        public int newdenum;
        public int bignum;
        public int nwd(int a, int b)
        {
            b = Math.Abs(b);
            if (a > 0 & b > 0)
            {
                while (a != b)
                {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
                return a;

            }
            else
            { 
                return 1;
            }
        }
        public void add(int num, int denum, int num2, int denum2)
        {
            if (denum == denum2)
            {
                newnum = num + num2;
                newdenum = denum;
            }
            else
            {

                newdenum = denum * denum2;
                newnum = denum * num2 + denum2 * num;
            }
            if (newnum != 0)
            {
                bignum = newnum / newdenum;
                if (bignum < 0)
                    newnum = (newnum % newdenum) * (-1);
                else
                    newnum = newnum % newdenum;
            }
            int nwdd = nwd(newdenum, newnum);
            if (nwdd != 1)
            {
                newdenum = newdenum / nwdd;
                newnum = newnum / nwdd;
            }
        }
        public void subtract(int num, int denum, int num2, int denum2)
        {
            if (denum == denum2)
            {
                newnum = num - num2;
                newdenum = denum;
            }
            else
            {
                newdenum = denum * denum2;
                newnum = denum2 * num - denum*num2;
            }
            if (newnum != 0)
            {
                bignum = newnum /newdenum;
                if(bignum<0)
                    newnum = (newnum % newdenum) * (-1);
                else
                    newnum = newnum % newdenum;
            }
            int nwdd = nwd(newdenum, newnum);
            if (nwdd != 1)
            {
                newdenum = newdenum / nwdd;
                newnum = newnum / nwdd;
            }
        }
        public void multi(int num, int denum, int num2, int denum2)
        {
            newnum = num * num2;
            newdenum = denum * denum2;
            if (newnum != 0)
            {
                bignum = newnum / newdenum;
                if (bignum < 0)
                    newnum = (newnum % newdenum) * (-1);
                else
                    newnum = newnum % newdenum;
            }
            int nwdd = nwd(newdenum, newnum);
            if (nwdd != 1)
            {
                newdenum = newdenum / nwdd;
                newnum = newnum / nwdd;
            }
        }
        public void divis(int num, int denum, int num2, int denum2)
        {
            newnum = num * denum2;
            newdenum = denum * num2;
            if (newnum != 0)
            {
                bignum = newnum / newdenum;
                if (bignum < 0)
                    newnum = (newnum % newdenum) * (-1);
                else
                    newnum = newnum % newdenum;
            }
            int nwdd = nwd(newdenum, newnum);
            if (nwdd != 1)
            {
                newdenum = newdenum / nwdd;
                newnum = newnum / nwdd;
            }
        }
    }
    public partial class Form1 : Form
    {
        fraction first = new fraction();
        fraction second = new fraction();

        public Form1()
        {
            InitializeComponent();
        }
        public void input()
        {
            int output1, output2;
            int.TryParse(textBox10.Text, out output1);
            int.TryParse(textBox9.Text, out output2);
            int.TryParse(textBox1.Text, out first.numerator);
            int.TryParse(textBox2.Text, out first.denominator);
            int.TryParse(textBox3.Text, out second.numerator);
            int.TryParse(textBox4.Text, out second.denominator);
            if (first.denominator == 0)
            {
                first.denominator = 1;
            }
            if (second.denominator==0)
            {
                second.denominator = 1;
            }
            if (output1!=0)
                {
                
                first.numerator = first.numerator + (output1*first.denominator);
            }
           
            if (output2!=0)
            {
             
                second.numerator = second.numerator+(output2*second.denominator);
            }
          
        }
        public void clear()
        {   if (textBox8.Text=="0" & textBox5.Text!="0")
            {
                textBox8.Text = String.Empty;
            }
            if (textBox5.Text=="0")
            {
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = "-";
            input();

            if ((first.denominator == 0) && (second.denominator == 0))
            {
                MessageBox.Show("Delete zeros from denominators.");
            }
            else
            {
                first.subtract(first.numerator, first.denominator, second.numerator, second.denominator);
                textBox5.Text = first.newnum.ToString();
                textBox6.Text = first.newdenum.ToString();
                textBox8.Text = first.bignum.ToString();
            }
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = "+";
            input();
            if ((first.denominator == 0) && (second.denominator == 0))
            {
                MessageBox.Show("Delete zeros from denominators.");
            }
            else
            {
                first.add(first.numerator, first.denominator, second.numerator, second.denominator);
                textBox5.Text = first.newnum.ToString();
                textBox6.Text = first.newdenum.ToString();
                textBox8.Text = first.bignum.ToString();
            }
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Text = "*";
            input();
            if ((first.denominator == 0) && (second.denominator == 0))
            {
                MessageBox.Show("Delete zeros from denominators.");
            }
            else
            {
                first.multi(first.numerator, first.denominator, second.numerator, second.denominator);
                textBox5.Text = first.newnum.ToString();
                textBox6.Text = first.newdenum.ToString();
                textBox8.Text = first.bignum.ToString();
            }
            clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox7.Text = "/";
            input();
            if ((first.denominator == 0) && (second.denominator == 0))
            {
                MessageBox.Show("Delete zeros from denominators.");
            }
            else
            {
                first.divis(first.numerator, first.denominator, second.numerator, second.denominator);
                textBox5.Text = first.newnum.ToString();
                textBox6.Text = first.newdenum.ToString();
                textBox8.Text = first.bignum.ToString();
            }
            clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
