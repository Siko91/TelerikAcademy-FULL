using BunnyEscape.Core;
using BunnyEscape.Core.GamePresets;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.ViewModels.ViewObjects
{
    public class CharacterViewObject : GameViewObject
    {
        public CharacterViewObject(CollidingObject obj, GameLevel GameLevel)
            : base(obj, GameLevel)
        {
        }

        internal void ShouldUpdateImage()
        {
            RaisePropertyChanged(() => this.ImagePath);
        }
    }
}
