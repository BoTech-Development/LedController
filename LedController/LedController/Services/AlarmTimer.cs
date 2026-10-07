using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedController.Services
{
    internal class AlarmTimer
    {
        public event Action Triggered;
        public bool IsRunning 
        { 
            get => _isRunning;
            set => _isRunning = value;
        } 
        private volatile bool _isRunning = false;
        public AlarmTimer(TimeOnly triggerTime, Action triggered)
        {
            Triggered = triggered;
            ExecuteTriggerWhenElapsedUntilEnded(triggerTime);
        }
        private void ExecuteTriggerWhenElapsedUntilEnded(TimeOnly triggerTime)
        {
            new Thread(() =>
            {
                while (_isRunning)
                {
                    TimeSpan delay = triggerTime - TimeOnly.FromDateTime(DateTime.Now);
                    if (delay < TimeSpan.Zero)
                        delay += TimeSpan.FromDays(1); // Adjust for next day if the time has already passed
                    Task.Delay(delay).Wait();
                    Triggered.Invoke();
                }
            }).Start();
        }
    }
}
