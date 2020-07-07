using System.Timers;
using InputTweaker.Logic.Action;
using InputTweaker.Logic.Trigger.TriggerState;

namespace InputTweaker.Logic.Trigger
{
    public class TimerTrigger
    {
        private readonly Timer _timer;

        public TimerTrigger(TimerTriggerState triggerState, ActionBase action)
        {
            _timer = new Timer(triggerState.Interval);
            _timer.Elapsed += (sender, eventArgs) =>
            {
                action.Execute(true);
            };
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        public void Cleanup()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}