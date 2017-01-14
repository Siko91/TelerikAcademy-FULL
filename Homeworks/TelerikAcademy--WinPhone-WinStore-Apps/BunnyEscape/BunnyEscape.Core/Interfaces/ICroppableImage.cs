namespace BunnyEscape.Core.Interfaces
{
    public interface ICroppableImage
    {
        Point2D VisivleAreaStartPosition { get; set; }

        Point2D VisibleAreaSize { get; set; }

        string ImagePath { get; set; }

        Point2D ImageSize { get; set; }

        bool IsVisible();
    }
}