using System;
using System.Collections.Generic;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.Data
{
    public class VisualElements
    {
        static Random rnd = new Random();

        #region Elements constructors
        public VisualElement Empty(int size)
        {
            return MakeElement(ConsoleColor.Black, size, size, ' ', ' ', true);
        }

        public VisualElement Hero(int size)
        {
            return MakeElement(ConsoleColor.White, size, size, '*', '*', true);
        }

        public VisualElement Barren(int size)
        {
            return MakeElement(ConsoleColor.DarkGray, size, size, ' ', '.', false);
        }

        public VisualElement Desert(int size)
        {
            return MakeElement(ConsoleColor.Yellow, size, size, ' ', '.', false);
        }

        public VisualElement Grass(int size)
        {
            return MakeElement(ConsoleColor.Green, size, size, ' ', '.', false);
        }

        public VisualElement Rock(int size)
        {
            return MakeElement(ConsoleColor.DarkGray, size, size, '#', '#', true);
        }

        public VisualElement NPC(int size)
        {
            return MakeElement(ConsoleColor.DarkRed, size, size, '?', '!', true);
        }
        #endregion

        #region Element building methods
        private VisualElement MakeElement(ConsoleColor color, int width, int height, char baseTexture, char randomTexture, bool isSolid)
        {
            VisualBrick[,] visuals = GetVisualsFilledWithColor(color, width, height, baseTexture);
            visuals = GenerateRandomTexture(visuals, randomTexture);

            return new VisualElement(visuals, null, isSolid);
        }

        private VisualBrick[,] GetVisualsFilledWithColor(ConsoleColor color, int rows, int cols, char ch)
        {
            VisualBrick[,] bricks = new VisualBrick[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    bricks[r, c].color = color;
                    bricks[r, c].ch = ch;
                }
            }
            return bricks;
        }

        private VisualBrick[,] GenerateRandomTexture(VisualBrick[,] bricks, char ch)
        {
            int row = rnd.Next(0, bricks.GetLength(0));
            int col = rnd.Next(0, bricks.GetLength(1));

            if (rnd.Next(0, 4) != 0) // 20% chance for not generating random texture
            {
                return bricks;
            }

            bricks[row, col].ch = ch;

            return bricks;
        }
        #endregion
    }
}
