using System.Collections.Generic;

namespace BunnyEscape.Core.GamePresets.Factories
{
    public class GameConfigurationFactory
    {
        private readonly Point2D levelSize = new Point2D(100, 50);
        private readonly Point2D visibleAreaSize = new Point2D(50, 40);
        private readonly Point2D visibleAreaStartPosition = new Point2D(20, 5);

        //private readonly Point2D levelSize = new Point2D(100, 50);
        //private readonly Point2D visibleAreaSize = new Point2D(110, 110);
        //private readonly Point2D visibleAreaStartPosition = new Point2D(-5, -25);

        internal GameLevel MakeLevel()
        {
            return new GameLevel(
                @"Resourses/Real/webs-2x2.jpg",
                this.levelSize,
                this.visibleAreaSize,
                this.visibleAreaStartPosition);
        }

        internal Player MakePlayer()
        {
            return Player.CreatePreset(
                new Point2D(this.levelSize.X * 20 / 30, this.levelSize.Y * 1 / 30),
                new Point2D(this.levelSize.X * 0.8 / 30, this.levelSize.Y * 2 / 30));
        }

        internal System.Collections.Generic.ICollection<Barrier> MakeBarriers()
        {
            return new BarrierFactory(this.levelSize).CreateBarriers();
            //return new List<Barrier>();
        }

        internal System.Collections.Generic.ICollection<EnemyGhost> MakeEnemies(Player player)
        {
            var list = new List<EnemyGhost>();
            list.Add(MakeSingleEnemy(player));
            return list;
        }
 
        public EnemyGhost MakeSingleEnemy(Player player)
        {
            return EnemyGhost.CreatePreset(
                new Point2D(this.levelSize.X * 10 / 30, this.levelSize.Y * 10 / 30),
                new Point2D(this.levelSize.X * 0.8 / 30, this.levelSize.Y * 2 / 30),
                player);
        }

        internal System.Collections.Generic.ICollection<KickableLightObject> MakeKickables()
        {
            return new KickableObjectsFactory(this.levelSize).CreateKickables();
            //return new List<KickableLightObject>();
        }

        internal System.Collections.Generic.ICollection<HeavyMovableObject> MakePushables()
        {
            return new PushableObjectFactory(this.levelSize).CreatePushables();
            //return new List<HeavyMovableObject>();
        }
    }
}