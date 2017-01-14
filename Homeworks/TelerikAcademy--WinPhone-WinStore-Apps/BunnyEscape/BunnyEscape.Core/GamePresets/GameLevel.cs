using System;
using System.Linq;

namespace BunnyEscape.Core.GamePresets
{
    public class GameLevel : CroppableImage
    {
        private const double borderOfPushingVisibleAreaAsPercentageOfScreen = 0.2;

        public GameLevel(string imagePath,
            Point2D size,
            Point2D croppedImageSize,
            Point2D croppedImageStartPosition) : base(imagePath,
            size,
            croppedImageSize,
            croppedImageStartPosition)
        {
        }

        public void UpdateScreenPosition(Player player)
        {
            Point2D pl = player.GetCenter();

            Point2D lvl = new Point2D(
                this.VisivleAreaStartPosition.X + this.VisibleAreaSize.X / 2,
                this.VisivleAreaStartPosition.Y + this.VisibleAreaSize.Y / 2
                );

            double differenceX = pl.X - lvl.X;
            double differenceY = pl.Y - lvl.Y;
            this.VisivleAreaStartPosition.X += differenceX;
            this.VisivleAreaStartPosition.Y += differenceY;
        }

        public Point2D ObjectPositionAsPercentageOfScreen(GameObject obj)
        {
            var relativePosition = new Point2D(
                (obj.Position.X - this.VisivleAreaStartPosition.X) / this.VisibleAreaSize.X,
                (obj.Position.Y - this.VisivleAreaStartPosition.Y) / this.VisibleAreaSize.Y);

            return relativePosition;
        }

        public Point2D ObjectSizeAsPercentageOfScreen(GameObject obj)
        {
            var sizeAsPercentageOfScreen = new Point2D(
                obj.Size.X / this.VisibleAreaSize.X,
                obj.Size.Y / this.VisibleAreaSize.Y);

            return sizeAsPercentageOfScreen;
        }
    }
}