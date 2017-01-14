using SazaracsMagicSword.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SazaracsMagicSword
{
    
    public static class LoadSaveGame
    {
        
        private static BinaryFormatter file = new BinaryFormatter();
        
        public static  void Save(Hero currentHero)
        {
            using (FileStream save = new FileStream(@"../../Data/Save/save.bin",FileMode.Create))
            {
                file.Serialize(save, currentHero);
            }

        }


        public static Hero Load()
        {
            using (FileStream load = new FileStream(@"../../Data/Save/save.bin", FileMode.Open))
            {
                return (Hero)file.Deserialize(load);
            }
        }
    }
}
