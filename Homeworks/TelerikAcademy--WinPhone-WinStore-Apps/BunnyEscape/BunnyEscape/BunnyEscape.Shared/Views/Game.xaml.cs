using BunnyEscape.Converters;
using BunnyEscape.Core;
using BunnyEscape.Core.GamePresets;
using BunnyEscape.ViewModels;
using BunnyEscape.ViewModels.ViewObjects;
using BunnyEscape.Core.GamePresets.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BunnyEscape.Core.GamePresets.Events;
using BunnyEscape.Handlers;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BunnyEscape.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        private const string PathToGameStartSound = @"Resourses\Sounds\melody-intro.wav";
        private const string PathToPlayerJumpSound = @"Resourses\Sounds\hsss.wav";
        private const string PathToPlayerMoveSound = @"Resourses\Sounds\pff2.wav";
        private const string PathToGhostPassingSound = @"Resourses\Sounds\guoooooo.wav";
        private const string PathToGhostBeingHitSound = @"Resourses\Sounds\pagrrr2.wav";
        private const string PathToKickableObjectCollisionSound = @"Resourses\Sounds\pagrrr.wav";
        private const string PathToPlayerDeadSound = @"Resourses\Sounds\melody-fail.wav";

        private ScreenPercentToWidthConverter widthConverter;
        private ScreenPercentToHeightConverter heightConverter;
        private GameViewModel Context;
        private DispatcherTimer timer;
        private Point lastClickedPosition;

        public Game()
        {
            this.InitializeComponent();
            this.Context = new GameViewModel();
            this.DataContext = this.Context;
            this.Context.SoundEvent = new EventHandler(OnSoundEvent);
            this.Context.PropertyChanged += OnContextPropertyChanged;

            this.widthConverter = new ScreenPercentToWidthConverter();
            this.heightConverter = new ScreenPercentToHeightConverter();
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            this.timer.Tick += new EventHandler<object>(this.OnTimerTick);
        }

        private void OnContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "GameOver")
            {
                if (this.Context.GameOver)
                {
                    this.OnGameOver();
                }
            }
        }

        private void OnGameOver()
        {
            this.DoubleTapped += OnAfterGameOverDoubleTapped;
        }

        private void OnAfterGameOverDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var frame = this.Frame;
            frame.GoBack();
            frame.Navigate(typeof(GameOverView), this.Context.Score);
        }

        private void OnSoundEvent(object sender, EventArgs e)
        {
            if (!(e is SoundEventArgs))
            {
                return;
            }
            SoundType soundType = (e as SoundEventArgs).SoundType;

            switch (soundType)
            {
                case SoundType.GameStart:
                    PlaySound(PathToGameStartSound);
                    break;
                case SoundType.PlayerJump:
                    PlaySound(PathToPlayerJumpSound);
                    break;
                case SoundType.PlayerMove:
                    PlaySound(PathToPlayerMoveSound);
                    break;
                case SoundType.GhostPassing:
                    PlaySound(PathToGhostPassingSound);
                    break;
                case SoundType.GhostBeingHit:
                    PlaySound(PathToGhostBeingHitSound);
                    break;
                case SoundType.KickableObjectCollision:
                    PlaySound(PathToKickableObjectCollisionSound);
                    break;
                case SoundType.PlayerDead:
                    PlaySound(PathToPlayerDeadSound);
                    break;
                default:
                    break;
            }
        }

        private void PlaySound(string soundPath)
        {
            // TODO: play a sound
        }

        private void OnTimerTick(object sender, object e)
        {
            HandleInput(lastClickedPosition);
        }

        private void OnPageTapped(object sender, TappedRoutedEventArgs e)
        {
            var pos = e.GetPosition(this.backgroundLayer);
            HandleInput(pos);
        }

        private void HandleInput(Point pos)
        {
            double percentPosX = widthConverter.ConvertBack(pos.X);
            double percentPosY = heightConverter.ConvertBack(pos.Y);

            double walkLeftMultyplyer = 1;
            double walkRightMultyplyer = 1;
            double jumpMultiplyer = 1;

            if (this.TurboInput != null)
            {
                walkLeftMultyplyer = this.TurboInput.WalkLeftMultyplyer;
                walkRightMultyplyer = this.TurboInput.WalkRightMultyplyer;
                jumpMultiplyer = this.TurboInput.JumpMultyplyer;
            }

            if (percentPosX < 0.5)
            {
                this.Context.MovePlayerLeft(walkLeftMultyplyer);
            }
            else
            {
                this.Context.MovePlayerRight(walkRightMultyplyer);
            }

            if (percentPosY < 0.5)
            {
                this.Context.MakePlayerJump(jumpMultiplyer);
            }
        }

        private void OnPagePointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var postions = e.GetIntermediatePoints(this.backgroundLayer);
            lastClickedPosition = postions.Last().Position;
        }

        private void OnPagePointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.timer.Start();
        }

        private void OnPagePointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.timer.Stop();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                bool turboMode = (bool)e.Parameter;
                if (turboMode)
                {
                    this.TurboInput = new TurboModeInputHandler();
                }
            }
            catch (InvalidCastException ice)
            {
            }
        }

        public TurboModeInputHandler TurboInput { get; set; }
    }
}
