using SharpTree.CLI.TreeItems;
using System;

namespace SharpTree.CLI.CLIUtils
{
    public static class TreeLevelExtensions
    {
        public static void ToCLI(this TreeLevel level)
        {
            string space = GetSpace(level);
            Console.WriteLine($@"{space} {level.Label}");
            foreach (var item in level.Items)
            {
                item.ToCLI();
            }
            foreach (var subLevel in level.SubLevels)
            {
                subLevel.ToCLI();
            }
        }
        public static void ToCLISelectable(this TreeLevel level)
        {
            string space = GetSpace(level);
            Console.WriteLine($@"{space} {level.Label}");
            foreach (var item in level.Items)
            {
                item.ToCLISelectable();
            }
            foreach (var subLevel in level.SubLevels)
            {
                subLevel.ToCLISelectable();
            }
        }

        private static string GetSpace(TreeLevel level)
        {
            return new string (' ', Constants.LEVELSPACELENGTH * level.Level);
        }
    }
}
