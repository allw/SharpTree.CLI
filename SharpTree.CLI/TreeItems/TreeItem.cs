namespace SharpTree.CLI.TreeItems
{
    public class TreeItem
    {
        public bool Selectable { get; set; }
        public bool Selected { get; set; }
        public string Label { get; set; }
        public int Level { get; set; }

        public TreeItem()
        {
        }

        public TreeItem(string label, int level)
            : this(label, level, false)
        {
        }

        public TreeItem(string label, int level, bool selectable)
        {
            Label = label;
            Level = level;
            Selectable = selectable;
        }
    }
}
