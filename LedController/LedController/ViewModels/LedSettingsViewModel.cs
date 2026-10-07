using LedController.Models;
using LedController.Models.Abstraction;
using LedController.ViewModels.Leds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LedController.ViewModels
{
    internal class LedSettingsViewModel : ViewModelBase
    {
        public ObservableCollection<LedViewModelBase> LedViewModels { get; } = new ObservableCollection<LedViewModelBase>();
        private List<ILed> Leds = new List<ILed>();
        public LedSettingsViewModel()
        {
            AddLed(new Led(20) 
            { 
                Brightness = 0.5 
            });
            AddLed(new RgbLed(26, 13, 19)
            {
                Brightness = 1.0
            });
            AddLed(new TimeLed(21)
            {
                Brightness = 0.5
            });
            AddLed(new TimeRgbLed(5, 6, 16)
            {
                Brightness = 1.0
            });
        }
        private void AddLed(ILed led)
        {
            LedViewModels.Add(led.GetViewModelFromActualImplementation());
            Leds.Add(led);
        }
    }
}
