using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Project_X
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(Program.sqlConnection);
        SqlCommand cmd;


        string udsername = Program.name;
        public Form2()
        {
            InitializeComponent();
            User_Name.Text = $"Welcome {udsername}";
            LoadProduct();

        }
        private void LoadProductsql()
        {


            products = new List<UserControl1>()
            {
                new UserControl1()
                {
                    Name="كوكاكولا",
                    Price="$1.4",
                    image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")


                },
                new UserControl1()
                {
                    Name="بيبسي",
                    Price="$1.5",
                     image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")

                }

            };
            foreach (UserControl1 item in products)
            {
                flowLayoutPanel1.Controls.Add(item);
            }

        }

        List<UserControl1> products;
        private void LoadProduct()
        {

            products = new List<UserControl1>()
            {
                new UserControl1()
                {
                    Name="كوكاكولا",
                    Price="$1.4",
                    image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")


                },
                new UserControl1()
                {
                    Name="بيبسي",
                    Price="$1.5",
                     image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")

                },
                new UserControl1()
                {
                    Name="عصير برتقال",
                    Price="$2.0",
                     image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")
                },
                new UserControl1()
                {
                    Name="عصير مانجي",
                    Price="$3.5",
                    image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")
                },
                new UserControl1()
                {
                    Name="عصير مانجي",
                    Price="$3.5",
                    image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")
                },
                new UserControl1()
                {
                    Name="عصير مانجي",
                    Price="$3.5",
                    image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")
                },
                new UserControl1()
                {
                    Name="قهوه",
                    Price="$1.9",
                     image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")
                },
                new UserControl1 ()
                {
                    Name ="بيتزا",
                    Price ="$100",
                    image = Image  .FromFile ("C:\\Users\\ytgsa\\Desktop\\Screenshot_4.png")


                }

            };
            foreach (UserControl1 item in products)
            {
                flowLayoutPanel1.Controls.Add(item);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Check = new Form1();
            Check.Show();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Admin Check = new Admin();
            Check.Show();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
