using SharpTree.CLI.TreeItems;
using System;

namespace SharpTree.CLI.CLIUtils
{
    public static class TreeItemExtensions
    {
        
        public static void ToCLI(this TreeItem item)
        {
            var space = GetSpace(item);
            Console.WriteLine($@"{space} {item.Label}");
        }

        public static void ToCLISelectable(this TreeItem item)
        {
            var space = GetSpace(item);
            var selected = item.Selected ? "x" : " ";
            var selectable = item.Selectable ? $" [{selected}]" : "";
            Console.WriteLine($@"{space}{selectable} {item.Label}");
        }

        public static int GetSpaceLength(this TreeItem item)
        {
            return Constants.LEVELSPACELENGTH * (item.Level + 1);
        }

        private static string GetSpace(this TreeItem item)
        {
            return new string(' ', item.GetSpaceLength());
        }
    }
}
