using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;

using GalaSoft.MvvmLight;

using BunnyEscape.Core.GamePresets.Events;
using BunnyEscape.ViewModels.ViewObjects;
using BunnyEscape.Core;
using BunnyEscape.Core.GamePresets;
using BunnyEscape.Core.GamePresets.ObserverInterfaces;

namespace BunnyEscape.ViewModels
{
    public class GameViewModel : ViewModelBase, IEngineObserver
    {
        private const string GameObjectsPropName = "GameObjects";

        private ICollection<GameViewObject> PushVOs;
        private ICollection<GameViewObject> KickVOs;
        private ICollection<CharacterViewObject> EnemyVOs;
        private ICollection<GameViewObject> BarriersVOs;
        private CharacterViewObject PlayerVO;
        private BackgroundViewObject BackgroundVO;
        private ObservableCollection<GameViewObject> gameObjects;
        private long score;

        public EventHandler SoundEvent;
        private bool gameOver;

        public GameViewModel()
        {
            this.GameEngine = Engine.CreateDefaultConfiguration();
            this.GameEngine.AttachObserver(this);
            this.GameEngine.RunAsync();
        }
        
        public IEnumerable<GameViewObject> GameObjects
        {
            get
            {
                if (this.gameObjects == null)
                {
                    this.gameObjects = new ObservableCollection<GameViewObject>();

                    foreach (var item in this.Pushables)
                    {
                        this.gameObjects.Add(item);
                    }
                    foreach (var item in this.Kickables)
                    {
                        this.gameObjects.Add(item);
                    }

                    gameObjects.Add(this.Player);

                    foreach (var item in this.Barriers)
                    {
                        this.gameObjects.Add(item);
                    }
                    foreach (var item in this.Enemies)
                    {
                        this.gameObjects.Add(item);
                    }
                }
                return this.gameObjects;
            }
        }

        public BackgroundViewObject Background
        {
            get
            {
                if (this.BackgroundVO == null)
                {
                    this.BackgroundVO = new BackgroundViewObject(GameEngine.Level);
                }
                return this.BackgroundVO;
            }
        }
        public CharacterViewObject Player
        {
            get
            {
                if (this.PlayerVO == null)
                {
                    this.PlayerVO = new CharacterViewObject(GameEngine.Player, GameEngine.Level);
                }
                return this.PlayerVO;
            }
        }

        public IEnumerable<GameViewObject> Barriers
        {
            get
            {
                if (this.BarriersVOs == null)
                {
                    this.BarriersVOs = new List<GameViewObject>();
                    foreach (var item in GameEngine.Barriers)
                    {
                        this.BarriersVOs.Add(new GameViewObject(item, GameEngine.Level));
                    }
                }
                return this.BarriersVOs;
            }
        }
        public IEnumerable<CharacterViewObject> Enemies
        {
            get
            {
                if (this.EnemyVOs == null)
                {
                    this.EnemyVOs = new List<CharacterViewObject>();
                    foreach (var item in GameEngine.Enemies)
                    {
                        this.EnemyVOs.Add(new CharacterViewObject(item, GameEngine.Level));
                    }
                }
                return this.EnemyVOs;
            }
        }
        public IEnumerable<GameViewObject> Kickables
        {
            get
            {
                if (this.KickVOs == null)
                {
                    this.KickVOs = new List<GameViewObject>();
                    foreach (var item in GameEngine.Kickables)
                    {
                        this.KickVOs.Add(new GameViewObject(item, GameEngine.Level));
                    }
                }
                return this.KickVOs;
            }
        }
        public IEnumerable<GameViewObject> Pushables
        {
            get
            {
                if (this.PushVOs == null)
                {
                    this.PushVOs = new List<GameViewObject>();
                    foreach (var item in GameEngine.Pushables)
                    {
                        this.PushVOs.Add(new GameViewObject(item, GameEngine.Level));
                    }
                }
                return this.PushVOs;
            }
        }

        public long Score {
            get 
            {
                return this.score;
            }
            set
            {
                if (this.score != value)
                {
                    this.score = value;
                    RaisePropertyChanged("Score");
                }
            }
        }

        public Engine GameEngine { get; set; }

        public void OnBarriersUpdate()
        {
            if (this.BarriersVOs == null)
            {
                return;
            }
            this.BarriersVOs = null;
            this.gameObjects = null;
            this.RaisePropertyChanged(GameObjectsPropName);
        }

        public void OnEnemiesUpdate()
        {
            if (this.EnemyVOs == null)
            {
                return;
            }
            this.EnemyVOs = null;
            this.gameObjects = null;
            this.RaisePropertyChanged(GameObjectsPropName);
        }

        public void OnKickablesUpdate()
        {
            if (this.KickVOs == null)
            {
                return;
            }
            this.KickVOs = null;
            this.gameObjects = null;
            this.RaisePropertyChanged(GameObjectsPropName);
        }

        public void OnPushablesUpdate()
        {
            if (this.PushVOs == null)
            {
                return;
            }
             this.PushVOs = null;
            this.gameObjects = null;
            this.RaisePropertyChanged(GameObjectsPropName);
        }

        public void OnGameTick()
        {
            this.Score = this.GameEngine.Score;

            this.Background.ShouldUpdate();
            this.Player.ShouldUpdate();

            foreach (var enemy in Enemies)
            {
                enemy.ShouldUpdate();
            }

            foreach (var kickable in Kickables)
            {
                kickable.ShouldUpdate();
            }

            foreach (var pushable in Pushables)
            {
                pushable.ShouldUpdate();
            }

            foreach (var barrier in Barriers)
            {
                barrier.ShouldUpdate();
            }
        }
        public void OnSoundEvent(SoundType soundType)
        {
            if (this.SoundEvent != null)
            {
                EventArgs args = new SoundEventArgs() { SoundType = soundType };
                this.SoundEvent(this, args);
            }
        }

        public void OnPlayerDeath()
        {
            this.GameOver = true;
        }

        public void OnPlayerImageUpdate()
        {
            this.Player.ShouldUpdateImage();
        }

        public void OnEnemyImageUpdate()
        {
            foreach (var enemy in Enemies)
            {
                enemy.ShouldUpdateImage();
            }
        }

        public void MakePlayerJump(double multyplyer)
        {
            this.GameEngine.Player.Jump(Force.PowerOfJumping * multyplyer);
        }

        public void MovePlayerRight(double multyplyer)
        {
            this.GameEngine.Player.GoToRight(Force.PowerOfWalking * multyplyer);
        }

        public void MovePlayerLeft(double multyplyer)
        {
            this.GameEngine.Player.GoToLeft(Force.PowerOfWalking * multyplyer);
        }


        public bool GameOver
        {
            get
            {
                return this.gameOver;
            }
            set
            {
                this.gameOver = value;
                RaisePropertyChanged("GameOver");
            }
        }
    }
}
