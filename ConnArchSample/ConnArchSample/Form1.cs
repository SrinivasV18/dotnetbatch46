using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnArchSample
{
    public partial class Form1 : Form
    {
        SqlDataReader dr;
        public Form1()
        {
            string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=mydb;User ID=sa;Password=sa@123";
            SqlConnection con1 = new SqlConnection(connectionString);

            con1.Open();
            SqlCommand cmd = new SqlCommand();
            string str = "select * from Employee";
            cmd.CommandText = str;
            cmd.Connection = con1;
            dr = cmd.ExecuteReader();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dr.Read();
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }
            //catch (Inv ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
