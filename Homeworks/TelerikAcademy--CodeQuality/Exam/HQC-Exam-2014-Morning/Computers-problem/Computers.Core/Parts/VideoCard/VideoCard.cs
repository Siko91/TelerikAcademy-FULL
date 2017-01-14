namespace Computers.Core.Parts.VideoCard
{
    using Interfaces;

    public abstract class VideoCard : IVideoCard
    {
        public abstract void Draw(string a);
    }
}