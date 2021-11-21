using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace Site_Inspection_System
{
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\Documents\Site Inspection.mdf;Integrated Security = True; Connect Timeout = 30");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) FROM UserTable where Username = '" + usernametb.Text + "' and Password = '" + passwordtb.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new HomeForm().Show();
            }
            else
                MessageBox.Show("Invalid username and password");

        }
    }
}
