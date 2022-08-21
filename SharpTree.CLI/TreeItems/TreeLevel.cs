using System.Collections.Generic;

namespace SharpTree.CLI.TreeItems
{
    public class TreeLevel
    {
        public string Label { get; set; }
        public List<TreeItem> Items { get; set; }
        public List<TreeLevel> SubLevels { get; set; }
        public int Level { get; set; }

        public TreeLevel()
        {
        }

        public TreeLevel(string label)
            : this(label, 1)
        {
        }
        public TreeLevel(string label, int level)
        {
            Label = label;
            Items = new List<TreeItem>();
            SubLevels = new List<TreeLevel>();
            Level = level;
        }

        public TreeLevel AddItem(string label)
        {
            return AddItem(label, false);
        }
        public TreeLevel AddItem(string label, bool selectable)
        {
            Items.Add(new TreeItem(label, Level, selectable));
            return this;
        }

        public TreeLevel AddSubLevel(TreeLevel subLevel)
        {
            subLevel.Level = Level + 1;
            foreach(var item in subLevel.Items)
            {
                item.Level = subLevel.Level;
            }
            SubLevels.Add(subLevel);
            return this;
        }
    }
}
