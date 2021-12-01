using ConsoleTools;
using System;
using System.Collections.Generic;

namespace GPA48P_HFT_2021221.Client
{
    public class MenuConfig
    {
        public ConsoleColor SelectedItemBackgroundColor = Console.ForegroundColor;
        public ConsoleColor SelectedItemForegroundColor = Console.BackgroundColor;
        public ConsoleColor ItemBackgroundColor = Console.BackgroundColor;
        public ConsoleColor ItemForegroundColor = Console.ForegroundColor;
        public Action WriteHeaderAction = () => Console.WriteLine("Pick an option:");
        public Action<MenuItem> WriteItemAction = item => Console.Write("[{0}] {1}", item.Index, item.Name);
        public string Selector = ">> ";
        public string FilterPrompt = "Filter: ";
        public bool ClearConsole = true;
        public bool EnableFilter = false;
        public string ArgsPreselectedItemsKey = "--menu-select=";
        public char ArgsPreselectedItemsValueSeparator = '.';
        public bool EnableWriteTitle = false;
        public string Title = "My menu";
        public Action<string> WriteTitleAction = title => Console.WriteLine(title);
        public bool EnableBreadcrumb = false;
        public Action<IReadOnlyList<string>> WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" > ", titles));
    }
}
