using LedController.ViewModels.Leds;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedController.Models.Abstraction
{
    internal interface ILed
    {
        /// <summary>
        /// upper range of <see cref="Brightness"/>
        /// </summary>
        public static double FullBrightness = 1.0;
        /// <summary>
        /// lower range of <see cref="Brightness"/>
        /// </summary>
        public static double LedOffBrightness = 0;
        /// <summary>
        /// Gets or sets the GPIO pin number for the LED.
        /// </summary>
        public int GpioPin { get; init; }
        /// <summary>
        /// Gets or sets the brightness of the LED. Value must be between 0 and 1.0.
        /// </summary>
        public double Brightness { get; set; }
        /// <summary>
        /// Createas a view model wrapper class to display this led.
        /// </summary>
        /// <returns></returns>
        public LedViewModelBase GetViewModelFromActualImplementation();
    }
}
