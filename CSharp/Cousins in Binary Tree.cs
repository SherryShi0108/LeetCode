//Source  : https://leetcode.com/problems/cousins-in-binary-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-08
//Language: C#

/*******************************************************************************************************************************
 * 
 * In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1.
 * Two nodes of a binary tree are cousins if they have the same depth, but have different parents.
 * We are given the root of a binary tree with unique values, and the values x and y of two different nodes in the tree.
 * Return true if and only if the nodes corresponding to the values x and y are cousins.
 *
 * Input: root = [1,2,3,4], x = 4, y = 3
 *              1
 *             / \
 *            2   3
 *           /  
 *          4   
 * Output: false
 *
 * Input: root = [1,2,3,null,4,null,5], x = 5, y = 4
 *              1
 *             / \
 *            2   3
 *             \   \
 *             4    5
 * Output: true
 *
 * Input: root = [1,2,3,null,4], x = 2, y = 3
 *              1
 *             / \
 *            2   3
 *             \ 
 *              4 
 * Output: false
 *
 * Constraints:
 *      The number of nodes in the tree will be between 2 and 100.
 *      Each node has a unique integer value from 1 to 100.
 *
 * ※
 *******************************************************************************************************************************/

/*
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
*/

public class Solution993
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        return false;
    }

}