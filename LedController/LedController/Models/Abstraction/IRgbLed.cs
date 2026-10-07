using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LedController.Models.Abstraction
{
    internal interface IRgbLed : ILed
    {
        /// <summary>
        /// The gpio pin for the Red channel of the RGB LED.
        /// </summary>
        public int GpioPin { get; init; }
        /// <summary>
        /// Gets or sets the GPIO pin number for the Green channel of the RGB LED.
        /// </summary>
        public int GpioPinGreen { get; init; }
        /// <summary>
        /// Gets or sets the GPIO pin number for the Blue channel of the RGB LED.
        /// </summary>
        public int GpioPinBlue { get; init; }
        /// <summary>
        /// Gets the current color of the RGB LED, factoring in the brightness property.
        /// </summary>
        public Color Color { get; }
        /// <summary>
        /// Sets the color of the RGB LED.
        /// Factors the brightness property into the color value.
        /// </summary>
        /// <param name="color">The color without brightness factor</param>
        public void SetColor(Color color);
    }
}
