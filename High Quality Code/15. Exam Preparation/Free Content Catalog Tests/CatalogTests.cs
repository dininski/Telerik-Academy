namespace Free_Content_Catalog_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Catalog;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using Catalog.Interfaces;

    [TestClass]
    public class CatalogTests
    {
        private static StringReader sr;

        [TestMethod]
        public void DefaultCatalogTest()
        {
            StringBuilder expectedOutput = new StringBuilder();
            StringBuilder actualOutput = new StringBuilder();

            actualOutput.AppendLine("No items found");
            actualOutput.AppendLine("Application added");
            actualOutput.AppendLine("Book added");
            actualOutput.AppendLine("Song added");
            actualOutput.AppendLine("Movie added");
            actualOutput.AppendLine("Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");
            actualOutput.AppendLine("Movie added");
            actualOutput.AppendLine("Movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/");
            actualOutput.AppendLine("Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");
            actualOutput.AppendLine("1 items updated");
            actualOutput.AppendLine("Book: Intro C#; S.Nakov; 12763892; http://introprograming.info/en/");
            actualOutput.AppendLine("0 items updated");


            StringBuilder input = new StringBuilder();
            input.AppendLine("Find: One; 3");
            input.AppendLine("Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org ");
            input.AppendLine("Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info");
            input.AppendLine("Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");
            input.AppendLine("Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d");
            input.AppendLine("Find: One; 1");
            input.AppendLine("Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/");
            input.AppendLine("Find: One; 10");
            input.AppendLine("Update: http://www.introprogramming.info; http://introprograming.info/en/");
            input.AppendLine("Find: Intro C#; 1");
            input.AppendLine("Update: http://nakov.com; sftp://www.nakov.com");
            input.AppendLine("End");
            input.AppendLine(string.Empty);

            sr = new StringReader(input.ToString());
            Console.SetIn(sr);

            using (sr)
            {
                StringBuilder output = new StringBuilder();
                ContentCatalog catalog = new ContentCatalog();
                ICommandExecutor executor = new CommandExecutor();
                List<ICommand> commands = catalog.Parse();

                foreach (ICommand command in commands)
                {
                    executor.ExecuteCommand(catalog, command, expectedOutput);
                }
            }

            Assert.AreEqual(expectedOutput.ToString(), actualOutput.ToString(), "Incorrect result");
        }
    }
}
