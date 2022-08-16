using SharpTree.CLI.TreeItems;
using System;

namespace SharpTree.CLI.CLIUtils
{
    public static class TreeExtensions
    {
        public static void ToCLI(this Tree item)
        {
            foreach (var level in item.Levels)
            {
                level.ToCLI();
            }
        }

        public static void ToCLISelectable(this Tree tree)
        {
            ConsoleKeyInfo key;
            int columnOffset = 3;
            int lineOffset = 3;
            int currentSelectedItem = 0;
            int currentLine = 0;

            var selectableItems = tree.GetSelectableItems();
            currentLine = selectableItems[currentSelectedItem].Line;
            do
            {

                Console.Clear();
                Console.WriteLine("Navigate up and down with arrows.");
                Console.WriteLine("Select with 'space bar' or 'x'");
                Console.WriteLine("Save with 'Enter'");
                foreach (var level in tree.Levels)
                {
                    level.ToCLISelectable();
                }
                if (selectableItems.Count > 0)
                {
                    currentLine = selectableItems[currentSelectedItem].Line;
                    Console.SetCursorPosition(selectableItems[currentSelectedItem].ColumnIndex + columnOffset, currentLine + lineOffset);
                }

                key = Console.ReadKey();
                if(key.Key == ConsoleKey.X || key.Key == ConsoleKey.Spacebar)
                {
                    selectableItems[currentSelectedItem].Item.Selected = !selectableItems[currentSelectedItem].Item.Selected;
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    if(currentSelectedItem < selectableItems.Count - 1)
                    {
                        currentSelectedItem++;
                    }
                }
                else if(key.Key == ConsoleKey.UpArrow)
                {
                    if(currentSelectedItem > 0)
                    {
                        currentSelectedItem--;
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();
        }
    }
}
