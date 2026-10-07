using System;
using System.Collections.Generic;
using System.Text;

namespace LedController.Models.Abstraction
{
    internal interface ITimeControlLed
    {
        /// <summary>
        /// Gets or sets the time when the LED should turn on.
        /// </summary>
        public TimeOnly TurnOnTime { get; set; }
        /// <summary>
        /// Gets or sets the time when the LED should turn off.
        /// </summary>
        public TimeOnly TurnOffTime { get; set; }
        /// <summary>
        /// Starts the timer to control the LED based on the specified turn-on and turn-off times.
        /// </summary>
        public void StartTimer();
        /// <summary>
        /// Stops the timer controlling the LED.
        /// </summary>
        public void StopTimer();
    }
}
