using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using InputInterceptorNS;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Enum;
using InputTweaker.Logic.Setting;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Trigger
{
    public class MouseTriggerOld
    {
        public static readonly MouseTriggerOld Instance = new MouseTriggerOld(); // Singleton

        private readonly LogWriter _logWriter = new LogWriter("Mouse Input");
        private MouseHook _mouseHookMove;
        private MouseHook _mouseHookButton;
        private MouseHook _mouseHookScroll;
        
        private readonly List<MouseButton> _pressedButtons = new List<MouseButton>();
        
        private Dictionary<MouseButton, Queue> _actionQueue = new Dictionary<MouseButton, Queue>();

        private MouseTriggerOld()
        {
        }
        
        public void Initialize()
        {
            MouseFilter mouseFilterButton = MouseFilter.All;
            mouseFilterButton &= ~(MouseFilter.Move | MouseFilter.ScrollHorizontal | MouseFilter.ScrollVertical);
            
            _mouseHookButton = new MouseHook(mouseFilterButton, (ref MouseStroke mouseStroke) =>
            {
                foreach (KeyValuePair<MouseButton, bool> keyValuePair in MouseStateToButtonStateDictionary(mouseStroke.State))
                {
                    if (_pressedButtons.Contains(keyValuePair.Key)) // was button pressed already?
                    {
                        if (!keyValuePair.Value) // released
                        {
                            _pressedButtons.Remove(keyValuePair.Key);
                            if ((bool) SettingsHandler.GetSetting(SettingKey.LogUnrecognized))
                            {
                                _logWriter.LogMessage($"{keyValuePair.Key} released");
                            }
                        }
                    }
                    else
                    {
                        if (keyValuePair.Value) // button is newly pressed
                        {
                            _pressedButtons.Add(keyValuePair.Key);
                            if ((bool) SettingsHandler.GetSetting(SettingKey.LogUnrecognized))
                            {
                                _logWriter.LogMessage($"{keyValuePair.Key} pressed");
                            }

                            if (_actionQueue.ContainsKey(keyValuePair.Key))
                            {
                                //((ActionBase)_actionQueue[keyValuePair.Key].Dequeue()).Execute(_actionQueue[keyValuePair.Key], keyValuePair.Key);
                            }
                        }
                    }
                    
                }
            });
            
            _mouseHookMove = new MouseHook(MouseFilter.Move, (ref MouseStroke mouseStroke) =>
            {
                
            });

            _mouseHookScroll = new MouseHook(MouseFilter.ScrollHorizontal | MouseFilter.ScrollVertical, (ref MouseStroke mouseStroke) =>
            {
                if ((bool)SettingsHandler.GetSetting(SettingKey.LogUnrecognized))
                {
                    _logWriter.LogMessage($"{mouseStroke.State} {mouseStroke.Rolling} {mouseStroke.Flags}");
                }
            });
        }

        public void Cleanup()
        {
            _mouseHookButton.Dispose();
            _mouseHookMove.Dispose();
            _mouseHookScroll.Dispose();
        }

        private static Dictionary<MouseButton, bool> MouseStateToButtonStateDictionary(MouseState mouseState)
        {
            Dictionary<MouseButton, Dictionary<MouseState, bool>> mouseButtonToMouseStateRelation =
                new Dictionary<MouseButton, Dictionary<MouseState, bool>>
                {
                    [MouseButton.Left] = new Dictionary<MouseState, bool> {[MouseState.LeftButtonDown] = true, [MouseState.LeftButtonUp] = false},
                    [MouseButton.Middle] = new Dictionary<MouseState, bool> {[MouseState.MiddleButtonDown] = true, [MouseState.MiddleButtonUp] = false},
                    [MouseButton.Right] = new Dictionary<MouseState, bool> {[MouseState.RightButtonDown] = true, [MouseState.RightButtonUp] = false},
                    [MouseButton.XButton1] = new Dictionary<MouseState, bool> {[MouseState.ExtraButton1Down] = true, [MouseState.ExtraButton1Up] = false},
                    [MouseButton.XButton2] = new Dictionary<MouseState, bool> {[MouseState.ExtraButton2Down] = true, [MouseState.ExtraButton2Up] = false},
                };

            Dictionary<MouseButton, bool> buttons = new Dictionary<MouseButton, bool>();
            
            foreach (KeyValuePair<MouseButton, Dictionary<MouseState, bool>> buttonStateSet in mouseButtonToMouseStateRelation)
            {
                foreach (KeyValuePair<MouseState, bool> mouseStatePressedSet in buttonStateSet.Value)
                {
                    if (mouseState.HasFlag(mouseStatePressedSet.Key))
                    {
                        buttons[buttonStateSet.Key] = mouseStatePressedSet.Value;
                    }
                }
            }

            return buttons;
        }

        public void AddAction(MouseButton button, ActionBase action)
        {
            if (!_actionQueue.ContainsKey(button))
            {
                _actionQueue[button] = new Queue();
            }

            _actionQueue[button].Enqueue(action);
        }
    }
}