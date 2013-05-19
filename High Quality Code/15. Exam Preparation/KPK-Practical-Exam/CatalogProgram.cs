using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using Catalog.Interfaces;

namespace Catalog
{
    public class CatalogProgram
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor executor = new CommandExecutor();

            List<ICommand> commands = Parse();

            foreach (ICommand command in commands)
            {
                executor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> commandsList = new List<ICommand>();
            bool isEndCommand = false;

            do
            {
                string currentCommand = Console.ReadLine();
                isEndCommand = (currentCommand.Trim() == "End");
                
                if (!isEndCommand)
                {
                    commandsList.Add(new Command(currentCommand));
                }

            }
            while (!isEndCommand);

            return commandsList;
        }
    }
}
