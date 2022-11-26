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
        SqlConnection con = new SqlConnection(Program.sqlConnection);
        SqlCommand cmd;
        byte tableSelected=0;


        

        public Admin()
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand($"select * from userss ;", con);
            newTableData(cmd);

        }
        private bool checkuser()
        {
            SqlCommand cmd = new SqlCommand($"select * from userss where username = '{textBox1.Text}' and password = '{textBox2.Text}';", con);
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            return ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

        }
        private void refreshTable()
        {
            if (tableSelected == 0)
            {
                SqlCommand cmd = new SqlCommand($"select * from userss ;", con);
                newTableData(cmd);

            }
            else if (tableSelected == 1)
            {
                SqlCommand cmd = new SqlCommand($"select * from cars ;", con);
                newTableData(cmd);
            }

        }
        private void query_Click(object sender, EventArgs e)
        {
            if (queryBox.Text != "")
            {
                try
                {
                    cmd = new SqlCommand($"{queryBox.Text}", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("query done");
                }
                catch (Exception)
                {
                    MessageBox.Show("pls enter valed data in query box");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("pls enter valed data in query box");
            }
            refreshTable();

        }

        private void newTableData(SqlCommand cmd)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        private void names_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from userss ;", con);
            newTableData(cmd);
            tableSelected = 0;
        }

        private void cars_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from cars ;", con);
            newTableData(cmd);
            tableSelected = 1;
        }

        private void bills_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from cars ;", con);
            newTableData(cmd);
            tableSelected = 2;
        }

        private void models_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from cars ;", con);
            newTableData(cmd);
            tableSelected = 3;
        }


        private void insert_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (checkuser())
                {
                    MessageBox.Show("user name is used");
                }
                else
                {
                    cmd = new SqlCommand($"INSERT INTO userss VALUES ('{textBox1.Text}','{textBox2.Text}')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("user created");
                }
            }
            else
            {
                MessageBox.Show("pls enter valed data");
            }
            refreshTable();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (checkuser())
                {
                    MessageBox.Show("user name is used");
                }
                else
                {
                    cmd = new SqlCommand($"UPDATE userss SET username = '{textBox1.Text}', password = '{textBox2.Text}' WHERE username = '{textBox1.Text}';", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("user Updated");
                }
            }
            else
            {
                MessageBox.Show("pls enter valed data");
            }
            refreshTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand($"select * from userss where username = '{textBox1.Text}';", con);
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool userExists = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (userExists)
                {
                    cmd = new SqlCommand($"DELETE FROM userss WHERE username = '{textBox1.Text}';", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("user deleted");

                }
                else
                {
                    MessageBox.Show("user name not exists");
                }
            }
            else
            {
                MessageBox.Show("pls enter valed data");
            }
            refreshTable();
        }


        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Check = new Form2();
            Check.Show();
        }
    }
}

