namespace Computers.Core.Parts.VideoCard
{
    using System;

    internal class MultychromeVideoCard : VideoCard
    {
        public override void Draw(string a)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(a);
            System.Console.ResetColor();
        }
    }
}