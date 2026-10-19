using System;
using System.Windows.Forms;
using CafeteriaDev.Core;
using CafeteriaDev.Forms;

namespace CafeteriaDev;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // The repository is shared by all windows for this application session.
        var salesRepository = new SalesRepository();

        using (var splashForm = new SplashForm())
        {
            splashForm.ShowDialog();
        }

        Application.Run(new MainForm(salesRepository));
    }
}
