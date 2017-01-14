using System;
using System.Collections.Generic;
using System.Linq;
using BunnyEscape.Core.GamePresets.Factories;
using BunnyEscape.Core.GamePresets.ObserverInterfaces;
using Windows.UI.Xaml;
using BunnyEscape.Core.GamePresets.Events;

namespace BunnyEscape.Core.GamePresets
{
    public class Engine : IObservedEngine
    {
        private const string ImagePath = "ImagePath";
        private DispatcherTimer Timer;

        private DispatcherTimer EnemyTimer;
        private bool PlayerAlreadyDied;

        public Engine(GameLevel level, Player player)
        {
            this.Level = level;
            this.Player = player;

            this.Player.ImageChangedEvent = new EventHandler(this.OnPlayerImageChanged);
            this.Player.SoundEvents = new EventHandler(this.OnSoundEvent);

            this.Barriers = new List<Barrier>();
            this.Enemies = new List<EnemyGhost>();
            this.Kickables = new List<KickableLightObject>();
            this.Pushables = new List<HeavyMovableObject>();
        }

        public long Score { get; set; }

        public bool IsRunning { get; set; }

        public bool ShouldStopRunning { get; set; }

        public GameLevel Level { get; set; }

        public Player Player { get; set; }

        public ICollection<Barrier> Barriers { get; set; }

        public ICollection<EnemyGhost> Enemies { get; set; }

        public ICollection<KickableLightObject> Kickables { get; set; }

        public ICollection<HeavyMovableObject> Pushables { get; set; }

        private ICollection<IEngineObserver> Observers { get; set; }

        public static Engine CreateDefaultConfiguration()
        {
            var factory = new GameConfigurationFactory();

            GameLevel level = factory.MakeLevel();
            Player pl = factory.MakePlayer();

            ICollection<Barrier> brs = factory.MakeBarriers();
            ICollection<EnemyGhost> enms = factory.MakeEnemies(pl);
            ICollection<KickableLightObject> kks = factory.MakeKickables();
            ICollection<HeavyMovableObject> pshs = factory.MakePushables();

            var engine = new Engine(level, pl);

            foreach (Barrier b in brs)
            {
                engine.AddBarrier(b);
            }

            foreach (EnemyGhost e in enms)
            {
                engine.AddEnemy(e);
            }

            foreach (KickableLightObject k in kks)
            {
                engine.AddKickable(k);
            }

            foreach (HeavyMovableObject p in pshs)
            {
                engine.AddPushable(p);
            }

            return engine;
        }

        public void AttachObserver(IEngineObserver observer)
        {
            if (this.Observers == null)
            {
                this.Observers = new List<IEngineObserver>();
            }
            this.Observers.Add(observer);
        }

        public void SoundShouldBePlayed(SoundType soundType)
        {
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnSoundEvent(soundType);
                }
            }
        }

        public void RunAsync()
        {
            if (this.IsRunning)
            {
                return;
            }
            this.IsRunning = true;
            this.ShouldStopRunning = false;

            this.Timer = new DispatcherTimer();
            this.Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            this.Timer.Tick += new EventHandler<object>(this.OnTimerTick);
            this.Timer.Start();

            this.EnemyTimer = new DispatcherTimer();
            this.EnemyTimer.Interval = new TimeSpan(0, 0, 0, 60, 0);
            this.EnemyTimer.Tick += new EventHandler<object>(this.OnEnemyTimerTick);
            this.EnemyTimer.Start();

            this.SoundShouldBePlayed(SoundType.GameStart);
        }
 
        public void Stop()
        {
            this.ShouldStopRunning = true;
        }

        public void AddBarrier(Barrier obj)
        {
            this.Barriers.Add(obj);
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnBarriersUpdate();
                }
            }
        }

        public void AddKickable(KickableLightObject obj)
        {
            this.Kickables.Add(obj);
            obj.SoundEvents = new EventHandler(this.OnSoundEvent);
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnKickablesUpdate();
                }
            }
        }

        public void AddPushable(HeavyMovableObject obj)
        {
            this.Pushables.Add(obj);
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnPushablesUpdate();
                }
            }
        }

        public void AddEnemy(EnemyGhost obj)
        {
            this.Enemies.Add(obj);
            obj.ImageChangedEvent = new EventHandler(this.OnEnemyImageChanged);
            obj.ScoreUpdatedEvent = new EventHandler(this.OnPointsScored);
            obj.SoundEvents = new EventHandler(this.OnSoundEvent);
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnEnemiesUpdate();
                }
            }
        }

        private void OnSoundEvent(object sender, EventArgs e)
        {
            if (e as SoundEventArgs != null)
            {
                this.SoundShouldBePlayed((e as SoundEventArgs).SoundType);
            }
        }

        private void OnPointsScored(object sender, EventArgs e)
        {
            var scoreArgs = e as ScoreEventArgs;
            if (scoreArgs == null)
            {
                return;
            }
            if (!this.Player.IsAlive)
            {
                return;
            }
            this.Score += scoreArgs.Score;
        }

        private void OnEnemyImageChanged(object sender, EventArgs e)
        {
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnEnemyImageUpdate();
                }
            }
        }

        private void OnPlayerImageChanged(object sender, EventArgs e)
        {
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnPlayerImageUpdate();
                }
            }
        }

        private void OnTimerTick(object sender, object e)
        {
            this.Update();
            if (this.Observers != null)
            {
                foreach (IEngineObserver obs in this.Observers)
                {
                    obs.OnGameTick();
                }
            }
        }
        private void OnEnemyTimerTick(object sender, object e)
        {
            this.AddEnemy(new GameConfigurationFactory().MakeSingleEnemy(this.Player));
        }
 

        private void Update()
        {
            if (this.IsRunning && !this.ShouldStopRunning)
            {
                this.CallOnUpdateMethods();
                this.ApplyForces();
                this.HandleCollisions();
                this.Level.UpdateScreenPosition(this.Player);

                if (!this.Player.IsAlive && !PlayerAlreadyDied)
                {
                    if (this.Observers != null)
                    {
                        this.PlayerAlreadyDied = true;
                        foreach (IEngineObserver obs in this.Observers)
                        {
                            obs.OnPlayerDeath();

                            this.SoundShouldBePlayed(SoundType.PlayerDead);
                        }
                    }
                }
            }
            else
            {
                this.Timer.Stop();
                this.Timer = null;

                this.EnemyTimer.Stop();
                this.EnemyTimer = null;

                this.IsRunning = false;
                this.ShouldStopRunning = true;
            }
        }

        private void CallOnUpdateMethods()
        {
            foreach (Barrier b in this.Barriers)
            {
                b.OnUpdate();
            }

            foreach (KickableLightObject k in this.Kickables)
            {
                k.OnUpdate();
            }

            foreach (HeavyMovableObject p in this.Pushables)
            {
                p.OnUpdate();
            }

            foreach (EnemyGhost e in this.Enemies)
            {
                e.OnUpdate();
            }

            this.Player.OnUpdate();
            this.Level.OnUpdate();
        }

        private void HandleCollisions()
        {
            this.HandleCollisionsFor(Player);

            foreach (Barrier b in this.Barriers)
            {
                this.HandleCollisionsFor(b);
            }

            foreach (HeavyMovableObject p in this.Pushables)
            {
                this.HandleCollisionsFor(p);
            }

            foreach (KickableLightObject k in this.Kickables)
            {
                this.HandleCollisionsFor(k);
            }

            foreach (EnemyGhost e in this.Enemies)
            {
                this.HandleCollisionsFor(e);
            }
        }
 
        private void HandleCollisionsFor(CollidingObject obj)
        {
            foreach (Barrier b in this.Barriers)
            {
                if (obj.ColidesWith(b) && obj != b)
                {
                    obj.OnCollisionWith(b);
                }
            }

            foreach (KickableLightObject k in this.Kickables)
            {
                if (obj.ColidesWith(k) && obj != k)
                {
                    obj.OnCollisionWith(k);
                }
            }

            foreach (HeavyMovableObject p in this.Pushables)
            {
                if (obj.ColidesWith(p) && obj != p)
                {
                    obj.OnCollisionWith(p);
                }
            }

            foreach (EnemyGhost e in this.Enemies)
            {
                if (obj.ColidesWith(e) && obj != e)
                {
                    obj.OnCollisionWith(e);
                }
            }

            if (obj.ColidesWith(this.Player) && obj != this.Player)
            {
                obj.OnCollisionWith(this.Player);
            }
        }

        private void ApplyForces()
        {
            this.Player.ApplyPhysicalEffects();

            foreach (EnemyGhost e in this.Enemies)
            {
                e.ApplyPhysicalEffects();
            }

            foreach (KickableLightObject k in this.Kickables)
            {
                k.ApplyPhysicalEffects();
            }

            foreach (HeavyMovableObject p in this.Pushables)
            {
                p.ApplyPhysicalEffects();
            }
        }
    }
}
