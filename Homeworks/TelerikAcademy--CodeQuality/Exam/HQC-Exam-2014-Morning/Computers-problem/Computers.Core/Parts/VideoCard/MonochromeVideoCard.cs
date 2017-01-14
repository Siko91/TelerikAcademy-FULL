namespace Computers.Core.Parts.VideoCard
{
    using System;

    internal class MonochromeVideoCard : VideoCard
    {
        public override void Draw(string a)
        {
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine(a);
            System.Console.ResetColor();
        }
    }
}