using BunnyEscape.Core;
using BunnyEscape.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BunnyEscape.ViewModels
{
    public class StoryViewModel : ViewModelBase
    {
        public StoryViewModel(DialogueModel dialogueModel = null)
        {
            this.dialogueModel = dialogueModel;
            if (this.dialogueModel == null)
	        {
                this.dialogueModel = DialogueModel.CreateDefaultDialogueModel();
            }

            this.CurrentBackgroundPath = this.dialogueModel.currentDialogue.Background;
            this.CurrentNpcDialogue = this.dialogueModel.currentDialogue.NpcDialogue;
            this.CurrentDialogueOptions = this.dialogueModel.currentDialogue.Responses;
        }

        private DialogueModel dialogueModel;
        private string currentNpcDialogue = String.Empty;
        private List<string> dialogueOptions = new List<string>();
        private string currentBackgroundPath = String.Empty;

        public string CurrentNpcDialogue
        {
            get
            {
                return currentNpcDialogue;
            }
            set
            {
                this.currentNpcDialogue = value;
                this.RaisePropertyChanged("CurrentNpcDialogue");
            }
        }
        public string CurrentBackgroundPath
        {
            get
            {
                return currentBackgroundPath;
            }
            set
            {
                this.currentBackgroundPath = value;
                this.RaisePropertyChanged("CurrentBackgroundPath");
            }
        }

        public IEnumerable<string> CurrentDialogueOptions
        {
            get 
            { 
                return dialogueOptions; 
            }
            set
            {
                dialogueOptions.Clear();
                dialogueOptions.AddRange(value);
                this.RaisePropertyChanged("CurrentDialogueOptions");
            }
        }

        public void GetNextDialogue()
        {
            var dialogue = this.dialogueModel.GetNextDialogue();

            if (dialogue == null)
            {
                DialogueFinished = true;
                return;
            }

            this.CurrentNpcDialogue = dialogue.NpcDialogue;
            this.CurrentBackgroundPath = dialogue.Background;

            IEnumerable<string> responses = dialogue.Responses;
            if (responses == null)
            {
                responses = new List<string>();
            }
            this.CurrentDialogueOptions = responses;
        }

        public bool DialogueFinished {get;set;}

        public Point2D DialogueBoxPos { get { return new Point2D(0.05, 0.2); } }
        public Point2D DialogueBoxSize { get { return new Point2D(0.9, 0.6); } }
        public Point2D NpcTextPos { get { return new Point2D(0.4, 0.27); } }
        public Point2D NpcTextSize { get { return new Point2D(0.5, 0.13); } }
        public Point2D ResponcesPos { get { return new Point2D(0.4, 0.4); } }
        public Point2D ResponcesSize { get { return new Point2D(0.5, 0.3); } }

        public Point2D SkipBtnPos { get { return new Point2D(0.9, 0.9); } }
        public Point2D SkipBtnSize { get { return new Point2D(0.1, 0.1); } }

        internal void OnActionWithoutResponseChoice()
        {
            if (this.CurrentDialogueOptions.Count() == 0)
            {
                this.GetNextDialogue();
            }
        }

        internal void OnActionWithResponseChoice()
        {
            this.GetNextDialogue();
        }
    }
}
