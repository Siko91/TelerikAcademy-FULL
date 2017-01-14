using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.Models
{
    public class DialogueModel
    {
        private const string BackgroundAngry = @"Resourses\Dialogue\bunny-angry.png";
        private const string BackgroundCurious = @"Resourses\Dialogue\bunny-curious.png";
        private const string BackgroundWholeBody = @"Resourses\Dialogue\bunny-whole-body.png";
        private const string BackgroundGhost = @"Resourses\Dialogue\ghost.png";
        private const string BackgroundSaw = @"Resourses\Dialogue\saw.png";

        public static DialogueModel CreateDefaultDialogueModel()
        {
            var dialogues = new List<Dialogue>
            {
                new Dialogue(BackgroundGhost, "Hey Bunny..."),
                new Dialogue(BackgroundSaw, "Hey Bunny... I wanna play a game!"),
                new Dialogue(BackgroundWholeBody, "Hey Bunny... I wanna play a game!", new List<string>
                    {
                        "Sure, lets play!",
                        "Hallo! Nice to meey you.",
                        "Hey! Shouldn't you be transperent?",
                    }),
                new Dialogue(BackgroundGhost, "Ahem!"),
                new Dialogue(BackgroundGhost, "I've trapped you in a *special* maze..."),
                new Dialogue(BackgroundGhost, "...and I'm going to KILL YOU!"),
                new Dialogue(BackgroundCurious, "...and I'm going to KILL YOU!", new List<string>
                    {
                        "Ahaaa...",
                        "Hmmmm...",
                        "I don't get it.",
                    }),
                new Dialogue(BackgroundGhost, "Stupid, stupid blonde rabbit!!"),
                new Dialogue(BackgroundGhost, "Killing you is BAD!!"),
                new Dialogue(BackgroundGhost, "You should be afraid!"),
                new Dialogue(BackgroundGhost, "You are going to be dead!"),
                new Dialogue(BackgroundGhost, "You are going to be dead! DEAD!"),
                new Dialogue(BackgroundCurious, "You are going to be dead! DEAD!", new List<string>
                    {
                        "I'm sorry! Please say it again. I'll be terrified, I promise",
                        "Oh, right! I guess that's *kind of* bad...",
                        "Dead? With this terrible makeup! Just give me a minute please!",
                    }),
                new Dialogue(BackgroundGhost, "<FACEPALM>"),
                new Dialogue(BackgroundGhost, "Bunny..."),
                new Dialogue(BackgroundGhost, "Bunny... There are spiders in this maze."),
                new Dialogue(BackgroundAngry, "Bunny... There are spiders in this maze.", new List<string>
                    {
                        "AAAAaaaaaaaAAA!!!",
                        "NO! Keep them away from me!",
                        "I must escape! I must escape!!",
                    })
            };

            return new DialogueModel(dialogues.ToArray());
        }

        private Dialogue[] dialogues;
        private int currentIndex;
        public Dialogue currentDialogue;

        private DialogueModel(Dialogue[] dialogues)
        {
            this.dialogues = dialogues;
            if (dialogues.Length > 0)
            {
                this.currentDialogue = dialogues[0];
                this.currentIndex = 0;
            }
        }

        public Dialogue GetNextDialogue() 
        {
            this.currentIndex++;
            if (currentIndex >= this.dialogues.Length)
            {
                this.currentDialogue = null;
            }
            else
	        {
                this.currentDialogue = this.dialogues[this.currentIndex];
	        }
            return this.currentDialogue;
        }
    }
}
