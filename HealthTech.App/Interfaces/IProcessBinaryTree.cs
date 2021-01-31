using HealthTech.App.Models;

namespace HealthTech.App.Interfaces
{
    public interface IProcessBinaryTree
    {
        TreeNode BuildTree(int treeDepth);
        bool RunBalls(int noOfBalls, TreeNode rootNode);
        void FindEmptyContainerId(TreeNode rootNode,int prediatedContainerIndex);
    }
}
