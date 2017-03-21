using System;
using System.Windows.Forms;
using PrEmpWin.Models;
using PrEmpWin.Views;

namespace PrEmpWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoMapperModelConfig.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmployeeForm());
        }
    }
}
