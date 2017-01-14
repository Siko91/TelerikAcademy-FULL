using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public string BackgroundImagePath { get { return @"Resourses\Real\background.gif"; } }

        public double BtnsLeftPositionPercent { get { return 0.35; } }
        public double BtnsTopPositionPercent { get { return 0.05; } }
        public double BtnHeightPercent { get { return 0.1; } }
        public double BtnWidthPercent { get { return 0.3; } }
    }
}
