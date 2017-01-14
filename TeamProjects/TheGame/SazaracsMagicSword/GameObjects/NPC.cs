using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{
    public class NPC : Human
    {
        //public List<string> conversation;
        private Position position;
        private string conversationPath;

        #region Properties
        public Position Position 
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public string ConversationPath
        {
            get { return this.conversationPath; }
            
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Conversation is empty!");
                }
 
                this.conversationPath = value;
            }
        }
        #endregion

        public NPC(string name, string conversationPath, string[] image)
            : base(name, image)
        {   
            this.ConversationPath = conversationPath;
        }
    }
}
