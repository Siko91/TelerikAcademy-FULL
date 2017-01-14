using BunnyEscape.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.ViewModels
{
    public interface IScoreViewModel
    {
        IEnumerable<IScore> Scores { get; set; }
        string Title { get; }
        string BackgroundImagePath { get; }

        double WidthOfColumn {get;}
    }
}
