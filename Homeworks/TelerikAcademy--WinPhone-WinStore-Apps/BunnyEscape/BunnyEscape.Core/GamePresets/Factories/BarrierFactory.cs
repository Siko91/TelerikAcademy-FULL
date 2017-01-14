using System;
using System.Collections.Generic;
using System.Linq;

namespace BunnyEscape.Core.GamePresets.Factories
{
    internal class BarrierFactory
    {
        public BarrierFactory(GameLevel gameLevel)
        {
            this.LevelSize = gameLevel.Size;
        }

        public BarrierFactory(Point2D levelSize)
        {
            this.LevelSize = levelSize;
        }

        public Point2D LevelSize { get; set; }

        internal ICollection<Barrier> CreateBarriers()
        {
            ICollection<Barrier> result = new List<Barrier>();

            // room Borders
            result.Add(this.MakeSolidWall(
                -LevelSize.Y * 4 / 30,
                -LevelSize.X * 4 / 30,
                Direction.Left
                ));

            result.Add(this.MakeSolidWall(
                0,
                LevelSize.X * 29 / 30,
                Direction.Right));

            result.Add(this.MakeSolidFloor(
                -LevelSize.Y * 4 / 30,
                -LevelSize.X * 4 / 30,
                Direction.Up));

            result.Add(this.MakeSolidFloor(
                LevelSize.Y * 29 / 30,
                0,
                Direction.Down));

            // floor 1
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 25.5 / 30, LevelSize.X * 6 / 30, LevelSize.X / 5.5));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 25.5 / 30, LevelSize.X * 14 / 30, LevelSize.X / 7));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 25.5 / 30, LevelSize.X * 24 / 30, LevelSize.X / 7));

            // floor 2
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 22 / 30, LevelSize.X * 1 / 30, LevelSize.X * 0.8 / 5));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 22 / 30, LevelSize.X * 18 / 30, LevelSize.X / 5));

            // floor 3
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 17.5 / 30, LevelSize.X * 3 / 30, LevelSize.X / 5.5));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 17.5 / 30, LevelSize.X * 15 / 30, LevelSize.X / 7));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 17.5 / 30, LevelSize.X * 24 / 30, LevelSize.X / 7));

            // floor 4
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 13 / 30, LevelSize.X * 1 / 30, LevelSize.X / 11));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 13 / 30, LevelSize.X * 10 / 30, LevelSize.X / 8));
            result.Add(this.MakeFloorPlatform(LevelSize.Y * 13 / 30, LevelSize.X * 18 / 30, LevelSize.X / 5));

            // Annoying walls
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 13 / 30, LevelSize.X * 1 / 30));
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 13 / 30, LevelSize.X * 13 / 30));
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 13 / 30, LevelSize.X * 21.5 / 30));
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 13 / 30, LevelSize.X * 28 / 30));

            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 22 / 30, LevelSize.X * 1 / 30));
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 22 / 30, LevelSize.X * 13 / 30));
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 22 / 30, LevelSize.X * 21.5 / 30));
            result.Add(this.MakeAnnoyingWall(LevelSize.Y * 22 / 30, LevelSize.X * 28 / 30));

            return result;
        }

        private Barrier MakeFloorPlatform(double top, double left, double width)
        {
            var barrier = new Barrier(
                new Point2D(left, top),
                new Point2D(width, this.LevelSize.Y / 30),
                @"Resourses/Real/block-h4.png");
            return barrier;
        }

        private Barrier MakeSolidFloor(double top, double left, Direction dir)
        {
            var barrier = new DirectionalBarrier(
                new Point2D(left, top),
                new Point2D(this.LevelSize.X * 35 / 30, this.LevelSize.Y * 5 / 30),
                @"Resourses/Real/block-h10.png",
                dir);
            return barrier;
        }

        private Barrier MakeSolidWall(double top, double left, Direction dir)
        {
            var barrier = new DirectionalBarrier(
                new Point2D(left, top),
                new Point2D(this.LevelSize.X * 5 / 30, LevelSize.Y * 35 / 30),
                @"Resourses/Real/block-v10.png",
                dir);
            return barrier;
        }

        private Barrier MakeAnnoyingWall(double top, double left)
        {
            var barrier = new Barrier(
                new Point2D(left, top),
                new Point2D(this.LevelSize.X / 30, this.LevelSize.Y * 2.5 / 30),
                @"Resourses/Real/block-v2.png");
            return barrier;
        }
    }
}