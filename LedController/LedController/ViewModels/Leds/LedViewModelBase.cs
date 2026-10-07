using LedController.Models.Abstraction;
using ReactiveUI;
using ReactiveUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedController.ViewModels.Leds
{
    internal class LedViewModelBase
    {
        public string DebugType => GetType().Name;
        /// <summary>
        /// Turns the led on or off on button click.
        /// </summary>
        public ReactiveCommand<RxVoid, RxVoid> ToggleLedOnOffCommand { get; init; }
        /// <summary>
        /// Redirects to the actual implemenatation of the Brightness property.
        /// </summary>
        public double SelectedBrightness
        {
            get => _actualLedImplementation.Brightness;
            set => _actualLedImplementation.Brightness = value;
        }
        /// <summary>
        /// The gpio which is connected to the led. get-only.
        /// </summary>
        public int Gpio
        {
            get => _actualLedImplementation.GpioPin;
        }
        /// <summary>
        /// The actual implementation of the led.
        /// </summary>
        protected ILed _actualLedImplementation { get; init; }
        public LedViewModelBase(ILed actualLedImplementation)
        {
            _actualLedImplementation = actualLedImplementation;
            ToggleLedOnOffCommand = ReactiveCommand.Create(() =>
            {
                if (_actualLedImplementation.Brightness == ILed.FullBrightness)
                {
                    _actualLedImplementation.Brightness = ILed.LedOffBrightness;
                }
                else
                {
                    _actualLedImplementation.Brightness -= ILed.FullBrightness;
                }
            });
        }
    }
}
