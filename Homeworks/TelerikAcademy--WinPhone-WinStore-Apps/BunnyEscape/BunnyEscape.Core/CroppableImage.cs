using System;
using System.Linq;
using BunnyEscape.Core.Interfaces;

namespace BunnyEscape.Core
{
    public class CroppableImage : CollidingObject, ICroppableImage
    {
        public CroppableImage(string imagePath, Point2D size, Point2D visibleAreaSize, Point2D visivleAreaStartPosition) : base(new Point2D(0, 0), size)
        {
            this.ImagePath = imagePath;
            this.ImageSize = size;
            this.VisivleAreaStartPosition = visivleAreaStartPosition;
            this.VisibleAreaSize = visibleAreaSize;
        }

        public Point2D VisivleAreaStartPosition { get; set; }

        public Point2D VisibleAreaSize { get; set; }

        public Point2D ImageSize { get; set; }

        public Point2D CroppedImageStartPositionPercantage
        {
            get
            {
                return new Point2D(
                    this.VisivleAreaStartPosition.X / this.Size.X,
                    this.VisivleAreaStartPosition.Y / this.Size.Y);
            }
        }

        public Point2D CroppedImageSizePercantage
        {
            get
            {
                return new Point2D(
                    this.VisibleAreaSize.X / this.Size.X,
                    this.VisibleAreaSize.Y / this.Size.Y);
            }
        }

        public bool IsVisible()
        {
            return true;
        }
    }
}