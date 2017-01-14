using System;
using System.Linq;

namespace BunnyEscape.Core.GamePresets.ObserverInterfaces
{
    public interface IObservedEngine
    {
        void AttachObserver(IEngineObserver observer);

        void SoundShouldBePlayed(SoundType soundType);
    }
}