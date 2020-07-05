using System.Timers;
using InputTweaker.Logic.Action;

namespace InputTweaker.Logic.Trigger
{
    public class TimerTrigger
    {
        private readonly Timer _timer;

        public TimerTrigger(double interval, ActionBase action)
        {
            _timer = new Timer(interval);
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