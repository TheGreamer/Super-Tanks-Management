using System;
using System.Windows.Forms;

namespace Super_Tanks_Management
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AllowedTanksForm());
        }
    }
}