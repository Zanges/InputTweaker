namespace InputTweaker.Logic.Trigger.TriggerState
{
    public class TimerTriggerState : ITriggerState
    { 
        public double Interval { get; private set; }
        
        public TimerTriggerState(double interval)
        {
            Interval = interval;
        }
    }
}