using System;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Trigger.TriggerState;
using Open.WinKeyboardHook;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace InputTweaker.Logic.Trigger
{
    public class VirtualKeyboardTrigger
    {
        private static readonly IKeyboardInterceptor Interceptor = new KeyboardInterceptor();
        private static bool _initialized;

        private VirtualKeyboardTriggerState _triggerState;
        private ActionBase _action;

        public VirtualKeyboardTrigger(VirtualKeyboardTriggerState triggerState, ActionBase action)
        {
            if (!_initialized)
            {
                _initialized = true;
                Interceptor.StartCapturing();
            }
            
            _triggerState = triggerState;
            _action = action;

            Interceptor.KeyDown += HandleDown;
            Interceptor.KeyUp += HandleUp;
        }

        private void HandleDown(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == _triggerState.Key)
            {
                args.SuppressKeyPress = _action.Execute(true);
            }
        }

        private void HandleUp(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == _triggerState.Key)
            {
                args.SuppressKeyPress = _action.Execute(false);
            }
        }
        
        
        public void Cleanup()
        {
            if (_initialized)
            {
                Interceptor.StopCapturing();
                _initialized = false;
            }
            
            Interceptor.KeyDown -= HandleDown;
            Interceptor.KeyUp -= HandleUp;
        }
    }
}