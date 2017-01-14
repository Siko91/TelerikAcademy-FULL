using System.Collections.Generic;

namespace BunnyEscape.Core.GamePresets.Factories
{
    public class PushableObjectFactory
    {
        private const double CrateSize = 4;

        public PushableObjectFactory(Point2D levelSize)
        {
            this.LevelSize = levelSize;
        }

        private Point2D LevelSize { get; set; }

        internal ICollection<HeavyMovableObject> CreatePushables()
        {
            var result = new List<HeavyMovableObject>();

            result.Add(this.MakePushable(this.LevelSize.Y * 10 / 30, this.LevelSize.X * 12 / 30));
            result.Add(this.MakePushable(this.LevelSize.Y * 20 / 30, this.LevelSize.X * 8 / 30));

            return result;
        }

        private HeavyMovableObject MakePushable(double top, double left)
        {
            return new HeavyMovableObject(
                new Point2D(left, top),
                new Point2D(CrateSize, CrateSize),
                @"Resourses/Real/crate.jpg");
        }
    }
}