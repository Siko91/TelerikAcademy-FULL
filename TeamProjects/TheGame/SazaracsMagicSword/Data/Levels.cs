using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.Data
{
    [Serializable]
    public class Levels
    {
        private int width = 80;
        private int height = 40;
        private string[] level1 = LoadData.LoadFile(@"../../Data/Levels/Level1.txt");
        private string[] level2 = LoadData.LoadFile(@"../../Data/Levels/Level2.txt");
        private string[] level3 = LoadData.LoadFile(@"../../Data/Levels/Level3.txt");

        public int Width { get { return this.width; } }
        public int Height { get { return this.height; } }
        public string[] Level1 { get { return this.level1; } }
        public string[] Level2 { get { return this.level2; } }
        public string[] Level3 { get { return this.level3; } }
    }
}

