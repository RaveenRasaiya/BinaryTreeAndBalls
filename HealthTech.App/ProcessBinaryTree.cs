using HealthTech.App.Interfaces;
using HealthTech.App.Models;
using System;

namespace HealthTech.App
{
    public class ProcessBinaryTree : IProcessBinaryTree
    {
        private static int nodeIndex;

        public TreeNode BuildTree(int treeDepth)
        {
            var rootNode = new TreeNode(TreeNode.GetTreeNodeGateState());
            nodeIndex = 0;
            Traverse(rootNode, 0, treeDepth);
            return rootNode;
        }

        public bool RunBalls(int noOfBalls, TreeNode rootNode)
        {
            for (int i = 1; i <= noOfBalls; i++)
            {
                TreeNode ballAtTreeNode = rootNode;

                do
                {
                    ballAtTreeNode = ToggleTreeGate(ballAtTreeNode);
                } while (ballAtTreeNode.LeftChildNode != null && ballAtTreeNode.RightChildNode != null);

                ballAtTreeNode.CountOfBalls += 1;                
            }
            return true;
        }


        public void FindEmptyContainerId(TreeNode rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            if (rootNode.CountOfBalls == 0 && rootNode.RightChildNode == null && rootNode.LeftChildNode == null)
            {
                Console.WriteLine($"4(a)->Empty Container Index :{rootNode.Index}");
            }
            FindEmptyContainerId(rootNode.LeftChildNode);
            FindEmptyContainerId(rootNode.RightChildNode);
        }

        #region " | PRIVATE METHODS |"

        private TreeNode ToggleTreeGate(TreeNode currentTreeNode)
        {
            if (currentTreeNode.GateState == TreeNodeGate.Left)
            {
                currentTreeNode.GateState = TreeNodeGate.Right;
                currentTreeNode = currentTreeNode.LeftChildNode;
            }
            else
            {
                currentTreeNode.GateState = TreeNodeGate.Left;
                currentTreeNode = currentTreeNode.RightChildNode;
            }

            return currentTreeNode;
        }

        private void Traverse(TreeNode treeNode, int rootIndex, int treeDepth)
        {
            if (rootIndex >= treeDepth)
            {
                treeNode.Index = ++nodeIndex;
                return;
            }

            treeNode.LeftChildNode = new TreeNode(TreeNode.GetTreeNodeGateState());
            treeNode.RightChildNode = new TreeNode(TreeNode.GetTreeNodeGateState());

            ++rootIndex;
            Traverse(treeNode.LeftChildNode, rootIndex, treeDepth);
         
            Traverse(treeNode.RightChildNode, rootIndex, treeDepth);
           
        }
        #endregion
    }
}
