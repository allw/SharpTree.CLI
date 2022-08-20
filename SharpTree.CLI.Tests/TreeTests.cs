using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTree.CLI.TreeItems;

namespace SharpTree.CLI.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void GetSelectableItems_WithNoSelectableItemsShouldReturn0()
        {
            var tree = new Tree()
                .AddLevel(new TreeLevel("Items 1").AddItem("Item 1"));

            var items = tree.GetSelectableItems();

            Assert.AreEqual(0, items.Count);
        }

        [TestMethod]
        public void GetSelectableItems_WithTwoSelectableItemsSouldReturn2()
        {
            var tree = new Tree()
                .AddLevel(new TreeLevel("Items 1").AddItem("Item 1", true).AddItem("Item 2", true));

            var items = tree.GetSelectableItems();

            Assert.AreEqual(2, items.Count);
        }

        [TestMethod]
        public void GetSelectableItems_FirstSelectableItemOnSecondLineOfFirstLevelShouldBeOnLine2()
        {
            var tree = new Tree()
                .AddLevel(new TreeLevel("Items 1").AddItem("Item 1").AddItem("Item 2", true));

            var items = tree.GetSelectableItems();

            Assert.AreEqual(2, items[0].Line);
        }
    }
}
