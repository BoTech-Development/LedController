using Avalonia.Media;
using LedController.Models;
using LedController.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedController.ViewModels.Leds
{
    internal class TimeRgbLedViewModel :  RgbLedViewModel
    {
        public TimeSpan TurnOnTime
        {
            get => GetTurnOnTimeFromActualImplementation();
            set => SetTurnOnTimeInActualImplementation(value);
        }
        public TimeSpan TurnOffTime
        {
            get => GetTurnOffTimeFromActualImplementation();
            set => SetTurnOffTimeInActualImplementation(value);
        }
        public TimeRgbLedViewModel(TimeRgbLed actualLedImplementation) : base(actualLedImplementation)
        {
        }
        private TimeSpan GetTurnOnTimeFromActualImplementation()
        {
            if (_actualLedImplementation is TimeRgbLed timeLed)
                return timeLed.TurnOnTime.ToTimeSpan();
            throw new InvalidOperationException("_actualledImplementation must be from type RgbLed!");
        }
        private TimeSpan GetTurnOffTimeFromActualImplementation()
        {
            if (_actualLedImplementation is TimeRgbLed timeLed)
                return timeLed.TurnOffTime.ToTimeSpan();
            throw new InvalidOperationException("_actualledImplementation must be from type RgbLed!");
        }
        private void SetTurnOnTimeInActualImplementation(TimeSpan value)
        {
            if (_actualLedImplementation is TimeLed timeLed)
            {
                // Is new turn on time before Turn off time?
                if (value < TurnOffTime)
                {
                    timeLed.TurnOnTime = TimeOnly.FromTimeSpan(value);
                }
            }
        }
        private void SetTurnOffTimeInActualImplementation(TimeSpan value)
        {
            if (_actualLedImplementation is TimeLed timeLed)
            {
                // Is new turn on time before Turn off time?
                if (value > TurnOnTime)
                {
                    timeLed.TurnOffTime = TimeOnly.FromTimeSpan(value);
                }
            }
        }
    }
}
