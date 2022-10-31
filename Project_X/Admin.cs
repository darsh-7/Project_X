using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_X
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("data Source=.;Initial Catalog=Car_System;Trusted_Connection=True;TrustServerCertificate=True;");
        SqlCommand cmd;


        public Admin()
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand($"select * from userss where username = '{username.Text}' and password = '{password.Text}';", con);
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
