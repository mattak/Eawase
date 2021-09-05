using System.Collections.Generic;
using UnityHooksLibrary.Page;

namespace Eawase.Application.Configuration
{
    public class Pages
    {
        private static readonly IReadOnlyDictionary<string, Page> pageMap =
            new Dictionary<string, Page>()
            {
                { "Title", new Page("Title", "Title") },
                { "Main", new Page("Main", "Main") },
            };

        public static Page Title => pageMap["Title"];
        public static Page Main => pageMap["Main"];
    }
}