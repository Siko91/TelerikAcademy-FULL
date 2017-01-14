using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.ViewModels
{
    public class HowToPlayViewModel : ViewModelBase
    {
        public double TitlesColumnWidth { get { return 0.1; } }

        public string WellcomeText
        {
            get
            {
                return @"This is *Bunny Escape* !
In this game you are a bunny trapped in a creepy maze, by an even creepier ghosts (They're not even trying to be transperent).
You can't possibly escape, but you are going to try it anyway.
Good luck!";
            }
        }
        public string WhatToDoText
        {
            get
            {
                return @"Avoid the ghosts (if they touch you - you die) and force them to hit as many obstacles as possible.
If you throw something at them, you get bonus points, but throwing stuff is hard when you're on a skateboard.
Don't waste time, becouse a new ghost will be spawning every minute!";
            }
        }
        public string ControlsText
        {
            get
            {
                return @"Tap or hold anywhere on the screen to control Bunny.
If you touch the upper part of the screen, she will try to jump.
If you tuch the right side of the screen, she'll go to the right.
To go left - tuch the left side of the screen.";
            }
        }
        public string ScoringText
        {
            get
            {
                return @"If a ghost is passing through a static object of any type, you'll recieve 20 points per second.
If the object is a moving rock, the bonus multiplyer is (x100)
For moving footballs the bonuis multiplyer is (x150)
Moving crates give you a bonus multiplyer of (x500)";
            }
        }

        public string BackgroundImagePath { get { return @"Resourses\Real\background.gif"; } }
    }
}
