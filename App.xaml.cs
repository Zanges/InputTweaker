using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace InputTweaker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        protected override void OnStartup(StartupEventArgs startupEventArgs)
        {
            base.OnStartup(startupEventArgs);

            string[] args = startupEventArgs.Args;

            if (args.Contains("-c") || args.Contains("--console"))
            {
                // console mode
                Console.WriteLine("Console mode active!");
                Console.ReadLine();
            }
            else
            {
                // GUI mode
                ShowWindow(GetConsoleWindow(), 0 /*SW_HIDE*/);

                var window = new MainWindow();

                window.ShowDialog();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
