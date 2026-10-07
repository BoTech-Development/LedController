using LedController.Models.Abstraction;
using LedController.Services;
using LedController.ViewModels.Leds;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedController.Models
{
    internal class TimeLed : Led, ITimeControlLed
    {
        private AlarmTimer? _turnOnTimer;
        private AlarmTimer? _turnOffTimer;
        public TimeOnly TurnOnTime
        {
            get;
            set
            {
                _turnOnTimer = new AlarmTimer(value, () => Brightness = 1.0);
                field = value;
            }
        }
        public TimeOnly TurnOffTime
        {
            get;
            set
            {
                _turnOffTimer = new AlarmTimer(value, () => Brightness = 0.0);
                field = value;
            }
        }

        public TimeLed(int gpioPin) : base(gpioPin)
        {
            
        }

        public void StartTimer()
        {
            if (_turnOnTimer == null || _turnOffTimer == null)
                throw new InvalidOperationException("TurnOnTime and TurnOffTime must be set before starting the timer.");
            _turnOffTimer.IsRunning = true;
            _turnOnTimer.IsRunning = true;
        }

        public void StopTimer()
        {
            if (_turnOnTimer == null || _turnOffTimer == null)
                throw new InvalidOperationException("TurnOnTime and TurnOffTime must be set before starting the timer.");
            _turnOffTimer.IsRunning = false;
            _turnOnTimer.IsRunning = false;
        }

        public override LedViewModelBase GetViewModelFromActualImplementation()
        {
            return new TimeLedViewModel(this);
        }
    }
}
