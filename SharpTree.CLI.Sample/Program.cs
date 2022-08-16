using SharpTree.CLI.CLIUtils;
using SharpTree.CLI.TreeItems;
using System;

namespace SharpTree.CLI.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree()
                .AddLevel(new TreeLevel("Items 1").AddItem("Item 1", true).AddItem("Item 2"));

            tree.AddLevel(new TreeLevel("Items 2").AddItem("Item 1").AddItem("Item 2")
                    .AddSubLevel(new TreeLevel("Items 2.1")
                        .AddItem("Item 1").AddItem("Item 2", true)));

            tree.AddLevel(new TreeLevel("Items 3").AddItem("Item 1", true).AddItem("Item 2", true));

            Console.WriteLine();

            tree.ToCLISelectable();

            Console.ReadKey();
        }
    }
}
