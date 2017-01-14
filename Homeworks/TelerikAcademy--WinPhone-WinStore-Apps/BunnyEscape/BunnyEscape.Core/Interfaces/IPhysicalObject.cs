using System;
using System.Collections.Generic;

namespace BunnyEscape.Core.Interfaces
{
    public interface IPhysicalObject
    {
        double Weight { get; set; }

        IList<Force> Forces { get; set; }

        void ApplyPhysicalEffects();

        void AddForce(Force force);
    }
}