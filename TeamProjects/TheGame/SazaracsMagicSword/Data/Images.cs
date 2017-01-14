using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.Data
{
    public class Images
    {
        #region Fileds
        private string[] humanWithSword = LoadData.LoadFile(@"../../Data/Images/HumanWithSword.txt");
        private string[] humanWithStaff = LoadData.LoadFile(@"../../Data/Images/HumanWithStaff.txt");
        private string[] humanOld = LoadData.LoadFile(@"../../Data/Images/HumanOld.txt");
        private string[] humanWithTwoSabers = LoadData.LoadFile(@"../../Data/Images/HumanWithTwoSabers.txt");
        private string[] humanWithShieldAndBigSword = LoadData.LoadFile(@"../../Data/Images/HumanWithShieldAndBigSword.txt");
        private string[] humanInFlame = LoadData.LoadFile(@"../../Data/Images/HumanInFlame.txt");
        private string[] damage = LoadData.LoadFile(@"../../Data/Images/Damage.txt");
        private string[] dog = LoadData.LoadFile(@"../../Data/Images/Dog.txt");
        private string[] gnome = LoadData.LoadFile(@"../../Data/Images/Gnome.txt");
        private string[] bear = LoadData.LoadFile(@"../../Data/Images/Bear.txt");
        private string[] demon = LoadData.LoadFile(@"../../Data/Images/Demon.txt");
        private string[] wareWolf = LoadData.LoadFile(@"../../Data/Images/WareWolf.txt");
        private string[] spider = LoadData.LoadFile(@"../../Data/Images/Spider.txt");
        private string[] introText = LoadData.LoadFile(@"../../Data/Images/IntroText.txt");
        private string[] gameOver = LoadData.LoadFile(@"../../Data/Images/GameOver.txt");
        #endregion

        #region Properties
        public string[] HumanWithSword { get { return this.humanWithSword; } }
        public string[] HumanWithStaff { get { return this.humanWithStaff; } }
        public string[] HumanOld { get { return this.humanOld; } }
        public string[] HumanWithTwoSabers { get { return this.humanWithTwoSabers; } }
        public string[] HumanWithShieldAndBigSword { get { return this.humanWithShieldAndBigSword; } }
        public string[] HumanInFlame { get { return this.humanInFlame; } }
        public string[] Damage { get { return this.damage; } }
        public string[] Dog { get { return this.dog; } }
        public string[] Gnome { get { return this.gnome; } }
        public string[] Bear { get { return this.bear; } }
        public string[] Demon { get { return this.demon; } }
        public string[] WareWolf { get { return this.wareWolf; } }
        public string[] Spider { get { return this.spider; } }
        public string[] IntroText { get { return this.introText; } }
        public string[] GameOver { get { return this.introText; } }
        #endregion    
    }
}
