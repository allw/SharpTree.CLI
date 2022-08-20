using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTree.CLI.TreeItems;

namespace SharpTree.CLI.Tests
{
    [TestClass]
    public class TreeLevelTests
    {
        [TestMethod]
        public void TreeLevel_DefaultCtorMakesLevel1()
        {
            var level = new TreeLevel("level");

            Assert.AreEqual(1, level.Level);
        }

        [TestMethod]
        public void TreeLevel_CtorWithGivenLevelShouldHaveInformedLevel()
        {
            int value = 2;
            var level = new TreeLevel("level", value);

            Assert.AreEqual(value, level.Level);
        }

        [TestMethod]
        public void AddItem_ItemLevelShouldHaveEqualLevel()
        {
            var level = new TreeLevel("level")
                .AddItem("item");

            Assert.AreEqual(level.Level, level.Items[0].Level);
        }

        [TestMethod]
        public void AddItem_OnALevel2ShouldHaveItemsWithLevel2()
        {
            var level = new TreeLevel("level", 2)
                .AddItem("item 1").AddItem("item 2");

            Assert.AreEqual(2, level.Items[0].Level);
            Assert.AreEqual(2, level.Items[1].Level);
        }

        [TestMethod]
        public void AddSubLevel_OnALevel2ShouldHaveItmsWithLevel3()
        {
            var level = new TreeLevel("level", 2)
                .AddItem("item 1").AddItem("item 2");
            level.AddSubLevel(new TreeLevel("sub level", 3).AddItem("item 2.1").AddItem("item 2.2"));

            Assert.AreEqual(3, level.SubLevels[0].Items[0].Level);
            Assert.AreEqual(3, level.SubLevels[0].Items[1].Level);
        }
    }
}
