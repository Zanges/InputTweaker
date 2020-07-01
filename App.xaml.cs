﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using InputTweaker.Logic.Setting;
using InputTweaker.Logic.Trigger;
using InputTweaker.View;

namespace InputTweaker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        void App_Startup(object sender, StartupEventArgs startupEventArgs)
        {
            string[] args = startupEventArgs.Args;

            SettingsHandler.Initialize();
            if (!args.Contains("--notrigger"))
            {
                //TriggerInitialisation.Instance.Initialize();
                TriggerManager.Initialize();
            }

            if (args.Contains("-g") || args.Contains("--guiless"))
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
            //TriggerInitialisation.Instance.Cleanup();
            TriggerManager.Cleanup();
        }
    }
}
