using System.Linq;
using Overlay.NET;
using Overlay.NET.Common;
using Process.NET;
using Process.NET.Memory;

namespace InputTweaker.Logic.Ui.Overlay
{
    public static class Overlay
    {
        private static OverlayPlugin _overlay;
        
        private static ProcessSharp _processSharp;

        private static bool _work;
        
        public static void Initialize()
        {
            string processName = "notepad"; 
            System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName(processName).FirstOrDefault();
            if (process == null) {
                Log.Warn($"No process by the name of {processName} was found.");
                Log.Warn("Please open one or use a different name and restart the demo.");
                return;
            }

            _processSharp = new ProcessSharp(process, MemoryType.Remote);
            
            _overlay = new WpfOverlay();

            WpfOverlay wpfOverlay = (WpfOverlay) _overlay;

            // This is done to focus on the fact the Init method
            // is overriden in the wpf overlay demo in order to set the
            // wpf overlay window instance
            wpfOverlay.Initialize(_processSharp.WindowFactory.MainWindow);
            wpfOverlay.Enable();

            _work = true;

            while (_work) {
                _overlay.Update();
            }
        }
    }
}