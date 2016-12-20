using System;
using System.Windows.Forms;
using DoubleJ.Oms.Service.Services;

namespace TestHarness
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DIService.Wire(new ApplicationModule());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DIService.Resolve<LauchPad>());
        }
    }
}
