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
            ToCLISelectable(tree, false);
        }

        public static void ToCLISelectable(this Tree tree, bool printInstructions)
        {
            ConsoleKeyInfo key;
            int columnOffset = 3;
            int lineOffset = printInstructions ? 3 : 0;
            int currentSelectedItem = 0;
            int currentLine = 0;

            var selectableItems = tree.GetSelectableItems();
            currentLine = selectableItems[currentSelectedItem].Line;

            if (printInstructions)
            {
                Console.Clear();
                Console.WriteLine("Navigate up and down with arrows.");
                Console.WriteLine("Select with 'Space bar' or 'x'");
                Console.WriteLine("Save with 'Enter'");
            }
            
            foreach (var level in tree.Levels)
            {
                level.ToCLISelectable();
            }
            if (selectableItems.Count > 0)
            {
                currentLine = selectableItems[currentSelectedItem].Line;
                Console.SetCursorPosition(selectableItems[currentSelectedItem].ColumnIndex + columnOffset, currentLine + lineOffset);
            }

            do
            {
                key = Console.ReadKey();
                if(key.Key == ConsoleKey.X || key.Key == ConsoleKey.Spacebar)
                {
                    var currentPosition = Console.GetCursorPosition();
                    if (!selectableItems[currentSelectedItem].Item.Selected)
                    {
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            Console.SetCursorPosition(currentPosition.Left - 1, currentPosition.Top);
                            Console.Write('x');
                        }
                        currentPosition = Console.GetCursorPosition();
                        Console.SetCursorPosition(currentPosition.Left - 1, currentPosition.Top);
                    }
                    else
                    {
                        Console.SetCursorPosition(currentPosition.Left - 1, currentPosition.Top);
                        Console.Write(' ');
                        currentPosition = Console.GetCursorPosition();
                        Console.SetCursorPosition(currentPosition.Left - 1, currentPosition.Top);
                    }
                    selectableItems[currentSelectedItem].Item.Selected = !selectableItems[currentSelectedItem].Item.Selected;
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    if(currentSelectedItem < selectableItems.Count - 1)
                    {
                        currentSelectedItem++;
                    }
                    currentLine = selectableItems[currentSelectedItem].Line;
                    Console.SetCursorPosition(selectableItems[currentSelectedItem].ColumnIndex + columnOffset, currentLine + lineOffset);
                }
                else if(key.Key == ConsoleKey.UpArrow)
                {
                    if(currentSelectedItem > 0)
                    {
                        currentSelectedItem--;
                    }
                    currentLine = selectableItems[currentSelectedItem].Line;
                    Console.SetCursorPosition(selectableItems[currentSelectedItem].ColumnIndex + columnOffset, currentLine + lineOffset);
                }
            } while (key.Key != ConsoleKey.Enter);
        }
    }
}
