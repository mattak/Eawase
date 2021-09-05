using System.Collections.Generic;

namespace Eawase.Application.Configuration
{
    public class Pages
    {
        private static readonly IReadOnlyDictionary<string, Page.Struct.Page> pageMap =
            new Dictionary<string, Page.Struct.Page>()
            {
                { "Title", new Page.Struct.Page("Title", "Title") },
                { "Main", new Page.Struct.Page("Main", "Main") },
            };

        public static Page.Struct.Page Title => pageMap["Title"];
        public static Page.Struct.Page Main => pageMap["Main"];
    }
}