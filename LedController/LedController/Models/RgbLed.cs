using LedController.Models.Abstraction;
using LedController.ViewModels.Leds;
using System;
using System.Collections.Generic;
using System.Device.Pwm;
using System.Device.Pwm.Drivers;
using System.Drawing;
using System.Text;

namespace LedController.Models
{
    internal class RgbLed : IRgbLed
    {
        private PwmChannel? _ledPwmChannelR;
        private PwmChannel? _ledPwmChannelG;
        private PwmChannel? _ledPwmChannelB;
        private Color _color;
        public Color Color
        {
            get
            {
                // Factor in the brightness property when getting the color
                int r = (_color.R * Brightness > 255) ? 255 : (int)(_color.R * Brightness);
                int g = (_color.G * Brightness > 255) ? 255 : (int)(_color.G * Brightness);
                int b = (_color.B * Brightness > 255) ? 255 : (int)(_color.B * Brightness);
                return Color.FromArgb(_color.A, r, g, b);
            }
        }
        public double Brightness 
        { 
            get => field;
            set
            {
                field = value;
                UpdatePwmChannels(); // Update the PWM duty cycle based on the new brightness
            }
        }
        public int GpioPin { get; init; }
        public int GpioPinGreen { get; init; }
        public int GpioPinBlue { get; init; }

        public RgbLed(int gpioPinRed, int gpioPinGreen, int gpioPinBlue)
        {
            GpioPin = gpioPinRed;
            GpioPinGreen = gpioPinGreen;
            GpioPinBlue = gpioPinBlue;
            try 
            { 
                _ledPwmChannelR = new SoftwarePwmChannel(GpioPin);
                _ledPwmChannelG = new SoftwarePwmChannel(GpioPinGreen);
                _ledPwmChannelB = new SoftwarePwmChannel(GpioPinBlue);
                _ledPwmChannelR.Start();
                _ledPwmChannelG.Start();
                _ledPwmChannelB.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing PWM channel for GPIO pin {GpioPin}: {ex.Message}");
            }
        }

        public void SetColor(Color color)
        {
            _color = color;
            UpdatePwmChannels();
        }
        private void UpdatePwmChannels()
        {
            if(_ledPwmChannelR != null && _ledPwmChannelG != null && _ledPwmChannelB != null)
            {
                Color colorWithBrightness = Color;
                _ledPwmChannelR.DutyCycle = colorWithBrightness.R / 255.0;
                _ledPwmChannelG.DutyCycle = colorWithBrightness.G / 255.0;
                _ledPwmChannelB.DutyCycle = colorWithBrightness.B / 255.0;
            }
        }

        public virtual LedViewModelBase GetViewModelFromActualImplementation()
        {
            return new RgbLedViewModel(this);
        }
    }
}
