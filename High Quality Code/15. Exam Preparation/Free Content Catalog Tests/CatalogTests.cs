namespace Free_Content_Catalog_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Catalog;
    using System.IO;
    using System.Text;

    [TestClass]
    public class CatalogTests
    {
        private static StringReader sr;
        private static StringWriter sw;

        [TestInitialize]
        public void InitializeWriter()
        {
            sw = new StringWriter();
        }

        [TestMethod]
        public void DefaultCatalogTest()
        {
            StringBuilder expectedOutput = new StringBuilder();
            StringBuilder actualOutput = new StringBuilder();

            using (sw)
            {
                Console.SetOut(sw);
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

                sr = new StringReader(input.ToString());
                using (sr)
                {
                    Console.SetIn(sr);

                    for (int i = 0; i < 12; i++)
                    {
                        actualOutput.AppendLine(Console.ReadLine());
                    }

                    expectedOutput.AppendLine("No items found");
                    expectedOutput.AppendLine("Application added");
                    expectedOutput.AppendLine("Book added");
                    expectedOutput.AppendLine("Song added");
                    expectedOutput.AppendLine("Movie added");
                    expectedOutput.AppendLine("Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");
                    expectedOutput.AppendLine("Movie added");
                    expectedOutput.AppendLine("Movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/");
                    expectedOutput.AppendLine("Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs");
                    expectedOutput.AppendLine("1 items updated");
                    expectedOutput.AppendLine("Book: Intro C#; S.Nakov; 12763892; http://introprograming.info/en/");
                    expectedOutput.AppendLine("0 items updated");
                }
            }

            Assert.AreEqual(expectedOutput.ToString(), actualOutput.ToString(), "Incorrect result");
        }
    }
}
