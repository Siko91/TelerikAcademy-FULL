using BunnyEscape.Core;
using BunnyEscape.Core.GamePresets;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.ViewModels.ViewObjects
{
    public class GameViewObject : ViewModelBase
    {
        public GameViewObject(CollidingObject obj, GameLevel GameLevel)
        {
            this.GameObject = obj;
            this.Level = GameLevel;
        }

        public CollidingObject GameObject { get; set; }
        public GameLevel Level { get; set; }

        public virtual void ShouldUpdate()
        {
            RaisePropertyChanged(() => this.WidthPercentage);
            RaisePropertyChanged(() => this.HeightPercentage);
            RaisePropertyChanged(() => this.PositionLeftPercentage);
            RaisePropertyChanged(() => this.PositionTopPercentage);
        }

        public double WidthPercentage
        {
            get
            {
                return this.Level.ObjectSizeAsPercentageOfScreen(this.GameObject).X;
            }
        }
        public double HeightPercentage
        {
            get
            {
                return this.Level.ObjectSizeAsPercentageOfScreen(this.GameObject).Y;
            }
        }
        public double PositionLeftPercentage
        {
            get
            {
                return this.Level.ObjectPositionAsPercentageOfScreen(this.GameObject).X;
            }
        }
        public double PositionTopPercentage
        {
            get
            {
                return this.Level.ObjectPositionAsPercentageOfScreen(this.GameObject).Y;
            }
        }
        public string ImagePath
        {
            get
            {
                return this.GameObject.ImagePath;
            }
        }
    }
}
