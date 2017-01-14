using System.Collections.Generic;

namespace BunnyEscape.Core.Interfaces
{
    public interface IGameObject
    {
        Point2D Position { get; set; }

        Point2D Size { get; set; }

        IEnumerable<Point2D> GetEdges();

        Point2D GetCenter();

        double DistanceTo(GameObject other);

        double AngleTo(GameObject other);

        void OnUpdate();
    }
}