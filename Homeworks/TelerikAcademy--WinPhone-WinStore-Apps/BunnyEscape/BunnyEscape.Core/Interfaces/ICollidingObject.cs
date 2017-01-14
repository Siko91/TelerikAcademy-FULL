namespace BunnyEscape.Core.Interfaces
{
    public interface ICollidingObject
    {
        string ImagePath { get; set; }

        bool ColidesWith(CollidingObject obj);

        bool PointIsInside(Point2D p);

        void OnCollisionWith(CollidingObject obj);
    }
}