using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BunnyEscape.Core;
using BunnyEscape.Core.GamePresets;
using GalaSoft.MvvmLight;

namespace BunnyEscape.ViewModels.ViewObjects
{
    public class BackgroundViewObject : ViewModelBase
    {
        public BackgroundViewObject(GameLevel level)
        {
            this.GameLevel = level;
        }
        public GameLevel GameLevel { get; set; }

        public void ShouldUpdate()
        {
            RaisePropertyChanged(() => this.OffsetTop);
            RaisePropertyChanged(() => this.OffsetLeft);
            RaisePropertyChanged(() => this.WidthAsPercent);
            RaisePropertyChanged(() => this.HeightAsPercent);
        }

        public double OffsetTop {
            get
            {
                double result = -GameLevel.CroppedImageStartPositionPercantage.Y * this.HeightAsPercent;
                return result;
            }
        }
        public double OffsetLeft {
            get
            {
                double result = -GameLevel.CroppedImageStartPositionPercantage.X * this.WidthAsPercent;
                return result;
            } 
        }
        public double WidthAsPercent
        { 
            get
            {
                if (GameLevel.VisibleAreaSize.X == 0)
                {
                    throw new ArgumentException("visible area is zero");
                }

                double result = GameLevel.Size.X / GameLevel.VisibleAreaSize.X;
                return result;
            } 
        }
        public double HeightAsPercent {
            get
            {
                if (GameLevel.VisibleAreaSize.Y == 0)
                {
                    throw new ArgumentException("visible area is zero");
                }

                double result = GameLevel.Size.Y / GameLevel.VisibleAreaSize.Y;
                return result;
            }
        }
        public string ImagePath 
        { 
            get 
            {
                return GameLevel.ImagePath;
            }
        }
    }
}
