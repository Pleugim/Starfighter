using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Starfighter.Core.Starfield;

namespace Starfighter.Core.Tests
{
    [TestClass]
    public class StarfieldTests
    {
        [TestMethod]
        public void TestGetAdjacent()
        {
            // Create two nodes.
            var nodeA = new StarNode();
            var nodeB = new StarNode();

            // Attempt to attach at position 0 of node A.
            var attachResult = nodeA.Attach(nodeB, 0);
            Assert.IsTrue(attachResult);

            // Verify they are attached.
            Assert.AreEqual(nodeB, nodeA.GetAdjacent(0));
            Assert.AreEqual(nodeA, nodeB.GetAdjacent(StarNode.GetOppositePosition(0)));

            // Create a third node.
            var nodeC = new StarNode();

            // Attempt to attach at position 0 and verify it fails.
            attachResult = nodeA.Attach(nodeC, 0);
            Assert.IsFalse(attachResult);

        }
    }
}
