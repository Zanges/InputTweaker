using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using InputTweaker.View;

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

        void App_Startup(object sender, StartupEventArgs startupEventArgs)
        {
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

                Window window = new MainWindow();
                window.ShowDialog();
            }
        }

        void App_Exit(object sender, ExitEventArgs exitEventArgs)
        {
        }
    }
}
