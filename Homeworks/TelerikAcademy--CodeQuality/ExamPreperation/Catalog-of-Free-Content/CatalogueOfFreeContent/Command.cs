namespace CatalogueOfFreeContent
{
    using CatalogueOfFreeContent.Enumerations;
    using CatalogueOfFreeContent.Interfaces;
    using System;
    using System.Text;

    public class Command : ICommand
    {
        private readonly char commandEnd = ':';
        private readonly char[] paramsSeparators = { ';' };

        private string name;

        private string orifinalForm;

        private string[] parameters;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of Command can not be empty");
                }
                this.name = value;
            }
        }

        public string OriginalForm
        {
            get
            {
                return this.orifinalForm;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Command's original form can not be empty");
                }
                this.orifinalForm = value;
                this.Parse(value);
            }
        }

        public string[] Parameters
        {
            get
            {
                return (string[])this.parameters.Clone();
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Command must have parametars");
                }
                this.parameters = value;
            }
        }

        public ExistingCommandType Type { get; set; }

        public int GetCommandNameEndIndex(string originalForm)
        {
            int endIndex = originalForm.IndexOf(this.commandEnd) - 1;

            return endIndex;
        }

        public ExistingCommandType ParseCommandType()
        {
            ExistingCommandTypeParser parser = new ExistingCommandTypeParser();
            return parser.Parse(this.name);
        }

        public string ParseName(string originalForm)
        {
            int commandNameEndIndex = this.GetCommandNameEndIndex(originalForm);
            string name = originalForm.Substring(0, commandNameEndIndex + 1);

            return name;
        }

        public string[] ParseParameters(string originalForm)
        {
            int commandNameEndIndex = this.GetCommandNameEndIndex(originalForm);
            int paramsLength = originalForm.Length - (commandNameEndIndex + 3);

            string paramsOriginalForm = originalForm.Substring(commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name);
            result.Append(" ");
            result.Append(string.Join(" ", this.Parameters));

            return result.ToString();
        }

        private void Parse(string originalForm)
        {
            this.Name = this.ParseName(originalForm);
            this.Parameters = this.ParseParameters(originalForm);
            this.Parameters = this.TrimParams(this.Parameters);

            this.Type = this.ParseCommandType();
        }

        private string[] TrimParams(string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            return parameters;
        }
    }
}