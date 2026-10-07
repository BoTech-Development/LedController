using LedController.Models;
using LedController.Models.Abstraction;
using ReactiveUI;
using ReactiveUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedController.ViewModels.Leds
{
    internal class LedViewModel : LedViewModelBase
    {
        public LedViewModel(Led actualLedImplementation) : base(actualLedImplementation)
        {
        }
    }
}
