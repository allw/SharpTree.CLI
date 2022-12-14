using SharpTree.CLI.TreeItems;
using SharpTree.CLI.Utils;
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

        public static Tree ToCLISelectable(this Tree tree)
        {
            return ToCLISelectable(tree, false);
        }

        public static Tree ToCLISelectable(this Tree tree, bool printInstructions)
        {
            Tree original = CloneUtils.DeepClone<Tree>(tree);

            ConsoleKeyInfo key;
            int columnOffset = 3;
            int lineOffset = printInstructions ? 3 : 1;
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
                else if(key.Key == ConsoleKey.Escape)
                {
                    return original;
                }
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            return tree;
        }
    }
}
