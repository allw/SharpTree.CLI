namespace SharpTree.CLI.TreeItems
{
    public class SelectableItemInfo
    {
        public int Line { get; set; }
        public int ColumnIndex { get; set; }
        public TreeItem Item { get; set; }

        public SelectableItemInfo(int line, int index, TreeItem item)
        {
            Line = line;
            ColumnIndex = index;
            Item = item;
        }
    }
}
