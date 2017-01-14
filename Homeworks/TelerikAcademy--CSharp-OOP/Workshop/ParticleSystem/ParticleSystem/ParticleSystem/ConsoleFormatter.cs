using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    class ConsoleFormatter
    {
        private int rows;
        private int cols;
        private ConsoleColor background;
        private ConsoleColor foreground;

        public ConsoleFormatter(int rows, int cols, ConsoleColor background, ConsoleColor foreground)
        {
            this.rows = rows;
            this.cols = cols;
            this.background = background;
            this.foreground = foreground;
        }
        public void Format()
        {
            Console.WindowHeight = rows;
            Console.WindowWidth = cols;
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
    }
}
