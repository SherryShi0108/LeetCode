﻿//Source  : https://leetcode.com/problems/merge-two-binary-trees/
//Author  : Xinruo Shi
//Date    : 2020-11-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.
 * You need to merge them into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.
 * Otherwise, the NOT null node will be used as the node of new tree.
 *
 * Input:
 *          Tree 1                     Tree 2
 *             1                         2
 *            / \                       / \
 *           3   2                     1   3
 *          /                           \   \
 *         5                             4   7
 *
 * Output: Merged tree:
 *              3
 *             / \
 *            4   5
 *           / \   \
 *          5   4   7
 *
 * Note: The merging process must start from the root nodes of both trees.
 * ※
 *******************************************************************************************************************************/

//public class TreeNode
//{
//    public int val;
//    public TreeNode left;
//    public TreeNode right;

//    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
//    {
//        this.val = val;
//        this.left = left;
//        this.right = right;
//    }
//}

public class Solution617
{
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
        return null;
    }

}