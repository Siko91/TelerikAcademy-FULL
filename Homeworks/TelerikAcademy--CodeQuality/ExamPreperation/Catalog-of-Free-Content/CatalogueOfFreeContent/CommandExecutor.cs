namespace CatalogueOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CatalogueOfFreeContent.Enumerations;
    using CatalogueOfFreeContent.Interfaces;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalogue, ICommand command, IContentFactory contentFactory, StringBuilder output)
        {
            switch (command.Type)
            {
                case ExistingCommandType.AddBook:
                    {
                        this.ExecuteCreateBookCommand(command, contentFactory, catalogue, output);
                        break;
                    }

                case ExistingCommandType.AddMovie:
                    {
                        this.ExecuteCreateMovieCommand(command, contentFactory, catalogue, output);
                        break;
                    }

                case ExistingCommandType.AddSong:
                    {
                        this.ExecuteCreateSongCommand(command, contentFactory, catalogue, output);
                        break;
                    }

                case ExistingCommandType.AddApplication:
                    {
                        this.ExecuteCreateApplicationCommand(command, contentFactory, catalogue, output);
                        break;
                    }

                case ExistingCommandType.Update:
                    {
                        this.ExecuteUpdateUrlCommand(command, catalogue, output);
                        break;
                    }

                case ExistingCommandType.Find:
                    {
                        this.ExecuteFindCommand(command, catalogue, output);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Unknown command!");
                    }
            }
        }

        private void ExecuteCreateApplicationCommand(ICommand command, IContentFactory contentFactory, ICatalog catalogue, StringBuilder output)
        {
            catalogue.Add(contentFactory.CreateApplication(command));
            output.AppendLine("Application added");
        }

        private void ExecuteCreateBookCommand(ICommand command, IContentFactory contentFactory, ICatalog catalogue, StringBuilder output)
        {
            catalogue.Add(contentFactory.CreateBook(command));
            output.AppendLine("Books Added");
        }

        private void ExecuteCreateMovieCommand(ICommand command, IContentFactory contentFactory, ICatalog catalogue, StringBuilder output)
        {
            catalogue.Add(contentFactory.CreateMovie(command));
            output.AppendLine("Movie added");
        }

        private void ExecuteCreateSongCommand(ICommand command, IContentFactory contentFactory, ICatalog catalogue, StringBuilder output)
        {
            catalogue.Add(contentFactory.CreateSong(command));
            output.AppendLine("Song added");
        }

        private void ExecuteFindCommand(ICommand command, ICatalog catalogue, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Find parameters must be 'title' and 'count'");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalogue.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }

        private void ExecuteUpdateUrlCommand(ICommand command, ICatalog catalogue, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Update parameters must be 'oldUrl' and 'newUrl'");
            }

            int updatedCount = catalogue.UpdateContent(command.Parameters[0], command.Parameters[1]);

            output.AppendLine(string.Format("{0} items updated", updatedCount));
        }
    }
}