using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Project_X
{
    internal static class Program
    {
        static public string sqlConnection = "data Source=.;Initial Catalog=Car_System;Trusted_Connection=True;TrustServerCertificate=True;";
        static public string name = "";
        static int accs = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Admin());
        }
        static public void newuser(string namee, int role)
        {
            name = namee;
            accs = role;
        }

    }
}
