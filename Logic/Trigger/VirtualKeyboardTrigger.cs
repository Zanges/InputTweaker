using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
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
        private static bool _initialized = false;

        private VirtualKeyboardTriggerState _triggerState;
        private Queue _actionQueue;

        public VirtualKeyboardTrigger(VirtualKeyboardTriggerState triggerState, Queue actionQueue)
        {
            if (!_initialized)
            {
                _initialized = true;
                Interceptor.StartCapturing();
            }
            
            _triggerState = triggerState;
            _actionQueue = actionQueue;

            switch (triggerState.TriggerOn)
            {
                case TriggerOn.Both:
                    Interceptor.KeyDown += Handle;
                    Interceptor.KeyUp += Handle;
                    break;
                case TriggerOn.Down:
                    Interceptor.KeyDown += Handle;
                    break;
                case TriggerOn.Up:
                    Interceptor.KeyUp += Handle;
                    break;
            }
        }

        private void Handle(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == _triggerState.Key)
            {
                args.SuppressKeyPress = _triggerState.Block;
                
                Queue newActionQueue = (Queue) _actionQueue.Clone();
                ActionBase firstAction = (ActionBase) newActionQueue.Dequeue();

                firstAction.Execute(newActionQueue, true);
            }
        }
        public void Cleanup()
        {
            if (_initialized)
            {
                Interceptor.StopCapturing();
                _initialized = false;
            }
            
            switch (_triggerState.TriggerOn)
            {
                case TriggerOn.Both:
                    Interceptor.KeyDown -= Handle;
                    Interceptor.KeyUp -= Handle;
                    break;
                case TriggerOn.Down:
                    Interceptor.KeyDown -= Handle;
                    break;
                case TriggerOn.Up:
                    Interceptor.KeyUp -= Handle;
                    break;
            }
        }
    }
}