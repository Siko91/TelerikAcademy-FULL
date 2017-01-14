using System.Collections.Generic;

namespace BunnyEscape.Core.GamePresets.Factories
{
    public class KickableObjectsFactory
    {
        private readonly Point2D LevelSize;

        public KickableObjectsFactory(Point2D levelSize)
        {
            this.LevelSize = levelSize;
        }

        internal ICollection<KickableLightObject> CreateKickables()
        {
            var result = new List<KickableLightObject>();

            result.Add(this.MakeFootball(LevelSize.Y * 14 / 30, LevelSize.X * 3 / 30));
            result.Add(this.MakeSmallRock(LevelSize.Y * 14 / 30, LevelSize.X * 18 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 14 / 30, LevelSize.X * 5 / 30));
            result.Add(this.MakeSmallRock(LevelSize.Y * 14 / 30, LevelSize.X * 15 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 14 / 30, LevelSize.X * 22 / 30));
            result.Add(this.MakeSmallRock(LevelSize.Y * 14 / 30, LevelSize.X * 25 / 30));

            result.Add(this.MakeFootball(LevelSize.Y * 20 / 30, LevelSize.X * 4 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 20 / 30, LevelSize.X * 17 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 20 / 30, LevelSize.X * 6 / 30));
            result.Add(this.MakeSmallRock(LevelSize.Y * 20 / 30, LevelSize.X * 16 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 20 / 30, LevelSize.X * 23 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 20 / 30, LevelSize.X * 26 / 30));

            result.Add(this.MakeFootball(LevelSize.Y * 27 / 30, LevelSize.X * 3 / 30));
            result.Add(this.MakeSmallRock(LevelSize.Y * 27 / 30, LevelSize.X * 18 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 27 / 30, LevelSize.X * 5 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 27 / 30, LevelSize.X * 15 / 30));
            result.Add(this.MakeFootball(LevelSize.Y * 27 / 30, LevelSize.X * 22 / 30));
            result.Add(this.MakeSmallRock(LevelSize.Y * 27 / 30, LevelSize.X * 25 / 30));

            return result;
        }

        private KickableLightObject MakeSmallRock(double top, double left)
        {
            var obj = new KickableLightObject(
                new Point2D(left, top),
                new Point2D(2, 2),
                @"Resourses/Real/rock.png",
                20);
            return obj;
        }

        private Football MakeFootball(double top, double left)
        {
            var obj = new Football(
                new Point2D(left, top),
                new Point2D(1, 1),
                @"Resourses/Real/football.png");
            return obj;
        }
    }
}