using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project_X
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("data Source=.;Initial Catalog=Car_System;Trusted_Connection=True;TrustServerCertificate=True;");
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private bool checkuser()
        {
            SqlCommand cmd = new SqlCommand($"select * from userss where username = '{username.Text}' and password = '{password.Text}';", con);
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            return ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

        }

        private void addUser(object sender, EventArgs e)
        {
            if (username.Text!=""&& password.Text != "")
            {
                if (checkuser())
                {
                    MessageBox.Show("user name is used");
                }
                else
                {
                    cmd = new SqlCommand($"INSERT INTO userss VALUES ('{username.Text}','{password.Text}')", con);
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
        }


        private void login(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {

                using (con)
                {

                    if (checkuser())
                    {
                        Program.name = username.Text;
                        con.Close();
                        this.Hide();
                        Form2 Check = new Form2();
                        Check.Show();
//                        Program.newuser(username.Text, 0);
                        //          this.close();
                        //          form2.Show(this);
                    }
                    else
                    {
                        MessageBox.Show("username or password not correct");
                    }
                }

            }
            else
            {
                MessageBox.Show("pls enter valed data");
            }


        }
    }
}
