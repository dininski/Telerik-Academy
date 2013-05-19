namespace Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Catalog.Interfaces;

    public class CatalogProgram
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            ContentCatalog catalog = new ContentCatalog();
            ICommandExecutor executor = new CommandExecutor();

            List<ICommand> commands = catalog.Parse();

            foreach (ICommand command in commands)
            {
                executor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }
    }
}
