//Source  : https://leetcode.com/problems/subtree-of-another-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-19
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree
 * of s. A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.
 *
 * Given tree s:
 *              3
 *             / \
 *            4   5
 *           / \
 *          1   2
 *
 * Given tree t:
 *               4
 *              / \
 *             1   2
 *
 * Return true, because t has the same structure and node values with a subtree of s.
 *
 * Given tree s:
 *               3
 *              / \
 *             4   5
 *            / \
 *           1   2
 *              /
 *             0
 *
 * Given tree t:
 *               4
 *              / \
 *             1   2
 *
 * Return false.
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

using System;
using System.Collections.Generic;

public class Solution572
{
    // --------------- O(n) 88ms --------------- O(n) 25MB --------------- (91% 91%) ※
    /*
     *  Using Recursive 
     */
    public bool IsSubtree_1(TreeNode s, TreeNode t)
    {

        return false;
    }
}