using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathLib;
using LoggerLib;

namespace MAthClassLibSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Calcs calcsObj = new Calcs();  

            int result = 0;
            int first = int.Parse(textBox1.Text);
            int second = int.Parse(textBox2.Text);
            result = calcsObj.Sum(first, second);
            MessageBox.Show("Sum-" + result);
            result = calcsObj.Sum(first, second, 30);
            MessageBox.Show("Sum-" + result);

            label1.Text = Logger.Success("Login Success...");

        }
    }
}
