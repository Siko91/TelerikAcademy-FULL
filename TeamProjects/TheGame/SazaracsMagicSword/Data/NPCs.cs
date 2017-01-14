using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.Data
{
    public class NPCs
    {
        static Images imgs = new Images();

        public List<NPC> npcList = new List<NPC>{
        // 0 "Filthy Dog"
        new NPC("Filthy Dog", @"../../Data/Conversations/FilthyDog.txt",
            imgs.Dog),
        // 1 "Quest Giver"
        new NPC("The Quest Giver", @"../../Data/Conversations/TheQuestGiver.txt",
            imgs.HumanWithSword),
         //2 "The Witch"
        new NPC("The Witch", @"../../Data/Conversations/TheWitch.txt",
            imgs.HumanOld),
        //// 3 "The Boring Guy"
        new NPC("The Boring Guy", @"../../Data/Conversations/TheBoringGuy.txt",
            imgs.HumanOld),
        //// 4 "The Smith"
        new NPC("The Smith", @"../../Data/Conversations/TheSmith.txt",
            imgs.HumanWithTwoSabers
            ),
        //// 5 "The Assassin"
        new NPC("The Assassin", @"../../Data/Conversations/TheAssasin.txt",
            imgs.HumanWithSword
            ),
        //// 6 "The Angry Man"
        new NPC("The Angry Man", @"../../Data/Conversations/TheAngryMan.txt",
            imgs.HumanWithSword),
        //// 7 "The Troll"
        new NPC("The Troll",@"../../Data/Conversations/TheTroll.txt",
            imgs.HumanOld),
        //// 8 "The Drunk"
        new NPC("The Drunk",@"../../Data/Conversations/TheDrunk.txt",
            imgs.HumanOld),
        //// 9 "The Guardian"
        new NPC("The Guardian",@"../../Data/Conversations/TheGuardian.txt",
            imgs.HumanWithSword)
        
        };
    }
}
