using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{
    public class VisualElement
    {
        public VisualBrick[,] ElementMatrix;
        public bool isSolid; /// player can not pass through solid elements;
        public DangerousTerritory content;

        public VisualElement(VisualBrick[,] ElementMatrix, DangerousTerritory content, bool isSolid)
        {
            this.ElementMatrix = ElementMatrix;
            this.content = content;
            this.isSolid = isSolid;
        }
    }
}
