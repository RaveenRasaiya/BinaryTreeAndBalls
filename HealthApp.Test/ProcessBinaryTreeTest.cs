using FluentAssertions;
using HealthTech.App;
using HealthTech.App.Interfaces;
using HealthTech.App.Models;
using System;
using Xunit;

namespace HealthApp.Test
{

    public class ProcessBinaryTreeTest
    {
        private readonly IProcessBinaryTree _processBinaryTree;
        public ProcessBinaryTreeTest()
        {
            _processBinaryTree = new ProcessBinaryTree();
        }

        [Fact]
        public void ProcessBinaryTree_RootNode_WithOutChildNodes()
        {
            TreeNode node = new TreeNode(TreeNodeGate.Left);
            node.Should().NotBeNull();
            node.RightChildNode.Should().BeNull();
            node.LeftChildNode.Should().BeNull();
        }

        [Fact]
        public void ProcessBinaryTree_BuildTreeWithDepth()
        {
            TreeNode node = new TreeNode(TreeNodeGate.Left);
            node.Should().NotBeNull();
            node = _processBinaryTree.BuildTree(2);
            node.RightChildNode.Should().NotBeNull();
            node.RightChildNode.Index.Should().Be(0);
            node.RightChildNode.RightChildNode.Index.Should().NotBe(0);
            node.RightChildNode.RightChildNode.Should().NotBeNull();
        }


        [Fact]
        public void ProcessBinaryTree_BuildTreeWithDepth_Left()
        {
            TreeNode node = new TreeNode(TreeNodeGate.Left);
            node.Should().NotBeNull();
            node = _processBinaryTree.BuildTree(2);
            node.LeftChildNode.Should().NotBeNull();
            node.LeftChildNode.Index.Should().Be(0);
            node.LeftChildNode.LeftChildNode.Index.Should().NotBe(0);
            node.LeftChildNode.LeftChildNode.Should().NotBeNull();
        }


        [Fact]
        public void ProcessBinaryTree_BuildTreeWithDepth_Right()
        {
            TreeNode node = new TreeNode(TreeNodeGate.Right);
            node.Should().NotBeNull();
            node = _processBinaryTree.BuildTree(5);
            node.RightChildNode.Should().NotBeNull();
            node.RightChildNode.Index.Should().Be(0);
            node.RightChildNode.RightChildNode.Should().NotBeNull();
            node.RightChildNode.RightChildNode.RightChildNode.Should().NotBeNull();
            node.RightChildNode.RightChildNode.RightChildNode.RightChildNode.Should().NotBeNull();
            node.RightChildNode.RightChildNode.RightChildNode.RightChildNode.RightChildNode.Should().NotBeNull();
            node.RightChildNode.RightChildNode.RightChildNode.RightChildNode.RightChildNode.Index.Should().NotBe(0);

        }


        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        public void ProcessBinaryTree_BuildTreeWithDepthAndPassBalls(int depth)
        {
            TreeNode node = new TreeNode(TreeNodeGate.Left);
            node.Should().NotBeNull();

            node = _processBinaryTree.BuildTree(depth);
            node.RightChildNode.Should().NotBeNull();
            node.RightChildNode.Index.Should().Be(0);
            node.RightChildNode.RightChildNode.Should().NotBeNull();

            _processBinaryTree.RunBalls((int)Math.Pow(2, depth) - 1, node);
            node.RightChildNode.CountOfBalls.Should().Be(0);
            node.LeftChildNode.CountOfBalls.Should().Be(0);
        }

        [Theory]
        [InlineData(4)]
        public void ProcessBinaryTree_BuildTreeWithDepthAndPassBalls_EmpthContainer(int depth)
        {
            TreeNode node = new TreeNode(TreeNodeGate.Left);
            node.Should().NotBeNull();

            node = _processBinaryTree.BuildTree(depth);
            node.RightChildNode.Should().NotBeNull();
            node.RightChildNode.Index.Should().Be(0);
            node.RightChildNode.RightChildNode.Should().NotBeNull();

            _processBinaryTree.RunBalls((int)Math.Pow(2, depth) - 1, node);
            node.RightChildNode.CountOfBalls.Should().Be(0);
            node.LeftChildNode.CountOfBalls.Should().Be(0);

            _processBinaryTree.FindEmptyContainerId(node, 11);
        }
    }
}
