using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project_X
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection(Program.sqlConnection);
        SqlCommand cmd;

        string[] tables = { "usersAccounts", "CarsDetails", "Bills", "CarsImages", "Customers", "Employees" };
        string tableSelected = "usersAccounts";

        public Admin()
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand($"select * from {tables[0]} ;", con);
            newTableData(cmd);

            TableName.Text = tableSelected;
            HideViewLables(2);
            HideViewLables(1, 4);
            label1.Text = "Name";
            label2.Text = "password";
            label3.Text = "roleId";
            label4.Text = "employeeSsn";
        }
        private bool checkExsist(string table = "users")
        {

            try
            {
                if (table == tables[0])
                    cmd = new SqlCommand($"select * from {tableSelected} where name = '{textBox1.Text}';", con);
                else if (table == tables[1])
                    cmd = new SqlCommand($"select * from {tableSelected} where id = '{textBox1.Text}';", con);
                else if (table == tables[2])
                    cmd = new SqlCommand($"select * from {tableSelected} where id = '{textBox1.Text}';", con);
                else if (table == tables[3])
                    cmd = new SqlCommand($"select * from {tableSelected} where id = '{textBox1.Text}';", con);
                else if (table == tables[4])
                    cmd = new SqlCommand($"select * from {tableSelected} where ssn = '{textBox1.Text}';", con);
                else if (table == tables[5])
                    cmd = new SqlCommand($"select * from {tableSelected} where ssn = '{textBox1.Text}';", con);

                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                return ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            }
            catch (Exception)
            {
                //MessageBox.Show("Enter valed data");
                con.Close();
            }

            return false;


        }
        private void HideViewLables(byte stats, byte num = 0)
        {
            if (stats == 1)
            {
                switch (num + 1)
                {
                    case 0:
                        break;
                    case 1:
                        label1.Visible = false;
                        label2.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;


                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        textBox5.Visible = false;
                        textBox6.Visible = false;
                        textBox7.Visible = false;
                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;
                    case 3:
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;


                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        textBox5.Visible = false;
                        textBox6.Visible = false;
                        textBox7.Visible = false;
                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;
                    case 4:
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;


                        textBox4.Visible = false;
                        textBox5.Visible = false;
                        textBox6.Visible = false;
                        textBox7.Visible = false;
                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;
                    case 5:
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;


                        textBox5.Visible = false;
                        textBox6.Visible = false;
                        textBox7.Visible = false;
                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;

                    case 6:
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;


                        textBox6.Visible = false;
                        textBox7.Visible = false;
                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;
                    case 7:
                        label7.Visible = false;
                        label8.Visible = false;
                        label9.Visible = false;

                        textBox7.Visible = false;
                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;
                    case 8:
                        label8.Visible = false;
                        label9.Visible = false;

                        textBox8.Visible = false;
                        textBox9.Visible = false;

                        break;
                    case 9:
                        label9.Visible = false;

                        textBox9.Visible = false;

                        break;


                }
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;


                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;

            }
        }
        private void refreshTable()
        {
            SqlCommand cmd = new SqlCommand($"select * from {tableSelected} ;", con);
            newTableData(cmd);
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
            SqlCommand cmd = new SqlCommand($"select * from {tables[0]} ;", con);
            newTableData(cmd);
            tableSelected = tables[0];
            TableName.Text = tableSelected;
            HideViewLables(2);
            HideViewLables(1, 4);
            label1.Text = "Name";
            label2.Text = "password";
            label3.Text = "roleId";
            label4.Text = "employeeSsn";
        }

        private void cars_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from {tables[1]} ;", con);
            newTableData(cmd);
            tableSelected = tables[1];
            TableName.Text = tableSelected;
            HideViewLables(2);
            HideViewLables(1, 9);
            label1.Text = "ID";
            label2.Text = "carModel";
            label3.Text = "color";
            label4.Text = "cost";
            label5.Text = "offer";
            label6.Text = "quantity";
            label7.Text = "Speed";
            label8.Text = "year";
            label9.Text = "catalogID";

        }

        private void bills_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from {tables[2]} ;", con);
            newTableData(cmd);
            HideViewLables(1, 5);
            tableSelected = tables[2];
            TableName.Text = tableSelected;
            label1.Text = "ID";
            label2.Text = "Date";
            label3.Text = "SellerAccount";
            label4.Text = "customerSsn";
            label5.Text = "carid";
        }

        private void models_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from {tables[3]} ;", con);
            newTableData(cmd);
            HideViewLables(1, 0);
            tableSelected = tables[3];
            TableName.Text = tableSelected;

        }
        private void customers_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from {tables[4]} ;", con);
            newTableData(cmd);
            HideViewLables(1, 0);

            tableSelected = tables[4];
            TableName.Text = tableSelected;
            HideViewLables(2);
            HideViewLables(1, 6);
            label1.Text = "SSN*";
            label2.Text = "Name*";
            label3.Text = "phone*";
            label4.Text = "Address";
            label5.Text = "email";
            label6.Text = "gender*";

        }
        private void employees_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from {tables[5]} ;", con);
            newTableData(cmd);
            tableSelected = tables[5];
            TableName.Text = tableSelected;
            HideViewLables(2);
            HideViewLables(1, 6);
            label1.Text = "SSN*";
            label2.Text = "Name*";
            label3.Text = "salary*";
            label5.Text = "phone*";
            label4.Text = "Address*";
            label6.Text = "job*";
        }

        private void insert_Click(object sender, EventArgs e)
        {
            bool boxEmpty3 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "";
            bool boxEmpty4 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "";
            bool boxEmpty5 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "" ;
            bool boxEmpty6 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "" && textBox6.Text != "" ;
            bool boxEmpty7 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "";
            bool boxEmpty9 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "";

            if (boxEmpty4)
            {

                if (!checkExsist() && tableSelected == tables[0])
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO {tableSelected} VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("user created");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("name is used or input data unvalied");
                        con.Close();
                    }

                }
                else if (!checkExsist(tables[1]) && tableSelected == tables[1] && boxEmpty9)
                {
                    try
                    {
                        /*                        label1.Text = "ID";
                                                label2.Text = "carModel";
                                                label3.Text = "color";
                                                label4.Text = "cost";
                                                label5.Text = "offer";
                                                label6.Text = "quantity";
                                                label7.Text = "Speed";
                                                label8.Text = "year";
                                                label9.Text = "catalogID";
                        */
                        cmd = new SqlCommand($"INSERT INTO CarsModels VALUES ('{textBox2.Text}','{textBox7.Text}','{textBox8.Text}','{textBox9.Text}')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand($"INSERT INTO Cars VALUES ('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("car added");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("data not valied");
                        con.Close();
                    }

                }
                else if (!checkExsist(tables[2]) && tableSelected == tables[2] && boxEmpty5)
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO {tableSelected} VALUES ('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("bill created");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("data not valied");
                        con.Close();
                    }

                }
                /*                else if (!checkExsist(tables[3]) && tableSelected == tables[3])
                                {
                                    try
                                    {
                                        cmd = new SqlCommand($"INSERT INTO {tableSelected} VALUES ('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        MessageBox.Show("car created");
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("data not valied");
                                        con.Close();
                                    }

                                }
                */
                else if (!checkExsist(tables[4]) && tableSelected == tables[4] && boxEmpty6)
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO {tableSelected} VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("customer created");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("data not valied");
                        con.Close();
                    }

                }
                else if (!checkExsist(tables[5]) && tableSelected == tables[5] && boxEmpty6)
                {
                    try
                    {
                        cmd = new SqlCommand($"INSERT INTO {tableSelected} VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("car created");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("data not valied");
                        con.Close();
                    }

                }


                else
                {
                    MessageBox.Show("primary key is used or data not valed");
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
            bool boxEmpty3 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "";
            bool boxEmpty4 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "";
            bool boxEmpty5 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "";
            bool boxEmpty6 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "" && textBox6.Text != "";
            bool boxEmpty7 = textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                                 && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "";

            if (boxEmpty4)
            {
                if (!checkExsist())
                {
                    MessageBox.Show("ID not exist");
                }
                else
                {
                    try
                    {
                        if (tableSelected == tables[0])
                            cmd = new SqlCommand($"UPDATE {tableSelected} SET name = '{textBox1.Text}', password = '{textBox2.Text}' , role= '{textBox3.Text}' employeeSsn = '{textBox4.Text}' WHERE name = '{textBox1.Text}';", con);
                        else if (tableSelected == tables[1])
                            cmd = new SqlCommand($"UPDATE {tableSelected} SET ID = '{textBox1.Text}', carModel = '{textBox2.Text}', quantity = '{textBox3.Text}'" +
                                $", cost = '{textBox4.Text}', carSpeed = '{textBox5.Text}', carYear = '{textBox6.Text}', colors = '{textBox7.Text}' WHERE carID = '{textBox1.Text}';", con);
                        else if (tableSelected == tables[2])
                            cmd = new SqlCommand($"UPDATE {tableSelected} SET Date = '{textBox2.Text}', userAccount = '{textBox3.Text}'" +
                                $", customer_Ssn = '{textBox4.Text}', carId = '{textBox5.Text}' WHERE id = '{textBox1.Text}';", con);
                        /*                        else if (tableSelected == tables[3])
                                                    cmd = new SqlCommand($"UPDATE {tableSelected} SET ID = '{textBox1.Text}', carModel = '{textBox2.Text}', quantity = '{textBox3.Text}'" +
                                                        $", cost = '{textBox4.Text}', carSpeed = '{textBox5.Text}', carYear = '{textBox6.Text}', colors = '{textBox7.Text}' WHERE carID = '{textBox1.Text}';", con);
                        */
                        else if (tableSelected == tables[4]&& textBox1.Text != "")
                            cmd = new SqlCommand($"UPDATE {tableSelected} SET ssn = '{textBox1.Text}', name = '{textBox2.Text}'" +
                                $", phone = '{textBox4.Text}', address = '{textBox5.Text}', email = '{textBox6.Text}', gender = '{textBox7.Text}' WHERE ssn = '{textBox1.Text}';", con);
                        else if (tableSelected == tables[4])
                            cmd = new SqlCommand($"UPDATE {tableSelected} SET ssn = '{textBox1.Text}', name = '{textBox2.Text}', Account = '{textBox3.Text}'" +
                                $", phone = '{textBox4.Text}', address = '{textBox5.Text}', email = '{textBox6.Text}', gender = '{textBox7.Text}' WHERE ssn = '{textBox1.Text}';", con);
                         else if (tableSelected == tables[5])
                            cmd = new SqlCommand($"UPDATE {tableSelected} SET ssn = '{textBox1.Text}', name = '{textBox2.Text}', salary = '{textBox3.Text}'" +
                                $", address = '{textBox4.Text}', phone = '{textBox5.Text}', job = '{textBox6.Text}' WHERE ssn = '{textBox1.Text}';", con);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("row Updated");
                    }
                    catch (Exception)
                    {
                        con.Close();
                        MessageBox.Show("pls enter valed data");
                    }
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
                if (checkExsist())
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("delete done");

                }
                else
                {
                    MessageBox.Show("error : row not exists or related to other table");
                    return;
                }

                if (tableSelected == tables[0])
                    cmd = new SqlCommand($"delete from {tableSelected} where name = '{textBox1.Text}';", con);
                else if (tableSelected == tables[1])
                    cmd = new SqlCommand($"delete from {tableSelected} where id = '{textBox1.Text}';", con);
                else if (tableSelected == tables[2])
                    cmd = new SqlCommand($"delete from {tableSelected} where id = '{textBox1.Text}';", con);
                else if (tableSelected == tables[3])
                    cmd = new SqlCommand($"delete from {tableSelected} where id = '{textBox1.Text}';", con);
                else if (tableSelected == tables[4])
                    cmd = new SqlCommand($"delete from {tableSelected} where ssn = '{textBox1.Text}';", con);
                else if (tableSelected == tables[5])
                    cmd = new SqlCommand($"delete from {tableSelected} where ssn = '{textBox1.Text}';", con);
            }
            else
            {
                MessageBox.Show("pls enter valed data");
            }
            refreshTable();
        }
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void back_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
            frm2.Show();
            this.Hide();

            //this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (tableSelected == tables[0])
                cmd = new SqlCommand($"select * from {tableSelected} WHERE name LIKE '%{searchBox.Text}%';", con);
            else if (tableSelected == tables[1])
                cmd = new SqlCommand($"select * from {tableSelected} WHERE model LIKE '%{searchBox.Text}%' or year LIKE '%{searchBox.Text}%';", con);
            else if (tableSelected == tables[2])
                cmd = new SqlCommand($"select * from {tableSelected} WHERE id LIKE '%{searchBox.Text}%';", con);
            else if (tableSelected == tables[3])
                cmd = new SqlCommand($"select * from {tableSelected} WHERE id LIKE '%{searchBox.Text}%';", con);
            else if (tableSelected == tables[4])
                cmd = new SqlCommand($"select * from {tableSelected} WHERE ssn LIKE '%{searchBox.Text}%' or name LIKE '%{searchBox.Text}%' or phone LIKE '%{searchBox.Text}%';", con);
            else if (tableSelected == tables[5])
                cmd = new SqlCommand($"select * from {tableSelected} WHERE ssn LIKE '%{searchBox.Text}%' or name LIKE '%{searchBox.Text}%' or phone LIKE '%{searchBox.Text}%';", con);

            newTableData(cmd);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

