using System;
using System.Windows.Forms;

namespace FraudGraphAnalyzer.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // .NET 6/7/8 WinForms helper. If using older .NET Framework, replace with Application.EnableVisualStyles() + SetCompatibleTextRenderingDefault().
            Application.Run(new MainForm());
        }
    }
}
