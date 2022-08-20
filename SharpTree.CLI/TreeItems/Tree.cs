using SharpTree.CLI.CLIUtils;
using System.Collections.Generic;

namespace SharpTree.CLI.TreeItems
{
    public class Tree
    {
        public List<TreeLevel> Levels { get; set; }

        public Tree()
        {
            Levels = new List<TreeLevel>();
        }

        public Tree AddLevel(TreeLevel level)
        {
            Levels.Add(level);
            return this;
        }

        public List<SelectableItemInfo> GetSelectableItems()
        {
            List<SelectableItemInfo> result = new List<SelectableItemInfo>();
            int line = 0;
            foreach(var level in Levels)
            {
                GetSelectableItemsInLevel(level, ref line, ref result);
            }
            return result;
        }

        private void GetSelectableItemsInLevel(TreeLevel level, ref int line, ref List<SelectableItemInfo> result)
        {
            line++;
            foreach (var item in level.Items)
            {
                if (item.Selectable)
                {
                    result.Add(new SelectableItemInfo(line, item.GetSpaceLength() - 1, item));
                }
                line++;

            }
            foreach (var subLevel in level.SubLevels)
            {
                GetSelectableItemsInLevel(subLevel, ref line, ref result);
            }
        }
    }
}
