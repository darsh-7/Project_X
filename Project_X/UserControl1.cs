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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        public string Name
        {
            get => lbl_name.Text;
            set => lbl_name.Text = value;
        }
        //set and get value to lblprice
        public string Price
        {
            get => lbl_price.Text;
            set => lbl_price.Text = value;
        }
        public Image image
        {
            get => pictureBox1.BackgroundImage;
            set => pictureBox1.BackgroundImage = value;
        }

        private void product_control_Load(object sender, EventArgs e)
        {

        }

        private void product_control_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void product_control_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            MessageBox.Show("أسم الصنف = '" + Name + "'");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_price_Click(object sender, EventArgs e)
        {

        }
    }
}

