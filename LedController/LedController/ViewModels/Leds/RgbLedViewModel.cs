using Avalonia.Media;
using LedController.Models;
using LedController.Models.Abstraction;
using System;


namespace LedController.ViewModels.Leds
{
    internal class RgbLedViewModel : LedViewModelBase
    {
        public Color Color
        {
            get => GetColorFromActualImplementation();
            set => SetColorToActualImplementation(value);
        }
        public RgbLedViewModel(RgbLed actualLedImplementation) : base(actualLedImplementation)
        {
        }
        private Color GetColorFromActualImplementation()
        {
            if(_actualLedImplementation is RgbLed rgbLed)
                return new Color(rgbLed.Color.A, rgbLed.Color.R, rgbLed.Color.G, rgbLed.Color.B);
            throw new InvalidOperationException("_actualledImplementation must be from type RgbLed!");
        }
        private void SetColorToActualImplementation(Color color)
        {
            if (_actualLedImplementation is RgbLed rgbLed)
                rgbLed.SetColor(System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B));
            throw new InvalidOperationException("_actualledImplementation must be from type RgbLed!");
        }
    }
}
