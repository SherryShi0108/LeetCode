//Source  : https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
//Author  : Xinruo Shi
//Date    : 2019-08-09
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given inorder and postorder traversal of a tree, construct the binary tree.
 * Note: You may assume that duplicates do not exist in the tree.
 * 
 * Input: 
 *      inorder = [9,3,15,20,7]
 *      postorder = [9,15,7,20,3]
 * Output: Return the following binary tree:
 *      3
 *     / \
 *    9  20
 *      /  \
 *     15   7
 * 
 *******************************************************************************************************************************/
public class TreeNode2
{
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode2(int x) { val = x; }
  }
/*******************************************************************************************************************************/
public class Solution106
{
    //public TreeNode BuildTree_1(int[] inorder, int[] postorder)
    //{

    //}

    //public TreeNode BuildTree_2(int[] inorder, int[] postorder)
    //{

    //}
}