using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{
    [Serializable]
    public class Human
    {
        private string name;
        private string[] image;

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name is empty! Please provide valid name!");

                this.name = value;
            }
        }

        public string[] Image
        {
            get { return this.image; }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("No image file provided!");

                this.image = value;
            }
        }

        protected Human(string name, string[] image)
        {
            this.Name = name;
            this.Image = image;
        }
    }
}
