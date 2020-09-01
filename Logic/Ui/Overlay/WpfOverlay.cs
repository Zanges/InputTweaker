using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using InputTweaker.Properties;
using Overlay.NET.Common;
using Overlay.NET.Wpf;
using Process.NET.Windows;

namespace InputTweaker.Logic.Ui.Overlay
{
    public class WpfOverlay : WpfOverlayPlugin
    {
        
        // Used to limit update rates via timestamps 
        // This way we can avoid thread issues with wanting to delay updates
        private readonly TickEngine _tickEngine = new TickEngine();

        private bool _isDisposed;

        private bool _isSetup;

        public override void Enable() {
            _tickEngine.IsTicking = true;
            base.Enable();
        }

        public override void Disable() {
            _tickEngine.IsTicking = false;
            base.Disable();
        }
        
        public override void Initialize(IWindow targetWindow) {
            // Set target window by calling the base method
            base.Initialize(targetWindow);

            OverlayWindow = new OverlayWindow(targetWindow);

            var type = GetType();

            // Set up update interval and register events for the tick engine.
            _tickEngine.Interval = new TimeSpan(100);
            _tickEngine.PreTick += OnPreTick;
            _tickEngine.Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs eventArgs) {
            // This will only be true if the target window is active
            // (or very recently has been, depends on your update rate)
            if (OverlayWindow.IsVisible) {
                OverlayWindow.Update();
            }
        }

        private void OnPreTick(object sender, EventArgs eventArgs) {
            // Only want to set them up once.
            if (!_isSetup) {
                SetUp();
                _isSetup = true;
            }

            var activated = TargetWindow.IsActivated;
            var visible = OverlayWindow.IsVisible;

            // Ensure window is shown or hidden correctly prior to updating
            if (!activated && visible) {
                OverlayWindow.Hide();
            }

            else if (activated && !visible) {
                OverlayWindow.Show();
            }
        }

        private void SetUp()
        {
            OverlayWindow.Add(new Polygon {
                                                      Points = new PointCollection(5) {
                                                          new Point(100, 150),
                                                          new Point(120, 130),
                                                          new Point(140, 150),
                                                          new Point(140, 200),
                                                          new Point(100, 200)
                                                      },
                                                      Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 255)),
                                                      Fill =
                                                          new RadialGradientBrush(
                                                              Color.FromRgb(255, 255, 0),
                                                              Color.FromRgb(255, 0, 255))
                                                  });
        }

        public override void Update() => _tickEngine.Pulse();

        // Clear objects
        public override void Dispose() {
            if (_isDisposed) {
                return;
            }

            if (IsEnabled) {
                Disable();
            }

            OverlayWindow?.Hide();
            OverlayWindow?.Close();
            OverlayWindow = null;
            _tickEngine.Stop();

            base.Dispose();
            _isDisposed = true;
        }

        ~WpfOverlay() {
            Dispose();
        }
    }
}