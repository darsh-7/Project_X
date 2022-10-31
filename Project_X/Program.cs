using System;
using System.Windows.Forms;

namespace Project_X
{
    internal static class Program
    {
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
            Application.Run(new Form1());
        }
        static public void newuser(string namee, int role)
        {
            name = namee;
            accs = role;
        }
    }
}
