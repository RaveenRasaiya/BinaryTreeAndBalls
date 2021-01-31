using System;

namespace HealthTech.App.Models
{
    public class TreeNode
    {
        public TreeNode(TreeNodeGate treeNodeGate)
        {
            GateState = treeNodeGate;
        }
        public int Index { get; set; }
        public string Name { get; set; }
        public int CountOfBalls { get; set; }
        public TreeNodeGate GateState { get; set; }
        public TreeNode LeftChildNode { get; set; }
        public TreeNode RightChildNode { get; set; }

        public static TreeNodeGate GetTreeNodeGateState()
        {
            Random random = new Random();

            int number = random.Next(1, 9999);

            return number % 2 == 0 ? TreeNodeGate.Right : TreeNodeGate.Left;
        }
    }
}
