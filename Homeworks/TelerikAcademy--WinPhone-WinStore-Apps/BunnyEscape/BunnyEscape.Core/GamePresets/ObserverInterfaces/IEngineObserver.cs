using System;
using System.Linq;

namespace BunnyEscape.Core.GamePresets.ObserverInterfaces
{
    public interface IEngineObserver
    {
        void OnGameTick();

        void OnBarriersUpdate();

        void OnEnemiesUpdate();

        void OnKickablesUpdate();

        void OnPushablesUpdate();

        void OnPlayerImageUpdate();

        void OnEnemyImageUpdate();

        void OnPlayerDeath();

        void OnSoundEvent(SoundType soundType);
    }
}