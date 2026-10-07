using LedController.Models.Abstraction;
using LedController.ViewModels.Leds;
using System;
using System.Collections.Generic;
using System.Device.Pwm;
using System.Device.Pwm.Drivers;
using System.Text;

namespace LedController.Models
{
    internal class Led : ILed
    {
        private PwmChannel? _ledPwmChannel;
        public int GpioPin { get; init; }
        public double Brightness
        {
            get => field;
            set
            {
                field = value;
                if(_ledPwmChannel != null)
                {
                    _ledPwmChannel.DutyCycle = value; // Update the PWM duty cycle based on the new brightness
                }
            }
        }

        public Led(int gpioPin)
        {
            GpioPin = gpioPin;
            try
            {
                _ledPwmChannel = new SoftwarePwmChannel(GpioPin);
                _ledPwmChannel.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing PWM channel for GPIO pin {GpioPin}: {ex.Message}");
            }
        }

        public virtual LedViewModelBase GetViewModelFromActualImplementation()
        {
            return new LedViewModel(this);
        }
    }
}
