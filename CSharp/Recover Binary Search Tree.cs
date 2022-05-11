//Source  : https://leetcode.com/problems/recover-binary-search-tree/
//Author  : Xinruo Shi
//Date    : 2022-05-01
//Language: C#

/*******************************************************************************************************************************
    You are given the root of a binary search tree (BST), where the values of exactly two
    nodes of the tree were swapped by mistake. Recover the tree without changing its structure.

    Input: root = [1,3,null,null,2]
    Output: [3,1,null,null,2]
    Explanation: 3 cannot be a left child of 1 because 3 > 1. Swapping 1 and 3 makes the BST valid.

    Input: root = [3,1,4,null,null,2]
    Output: [2,1,4,null,null,3]
    Explanation: 2 cannot be in the right subtree of 3 because 2 < 3. Swapping 2 and 3 makes the BST valid.
 
    Constraints:
        The number of nodes in the tree is in the range [2, 1000].
        -2^31 <= Node.val <= 2^31 - 1
 ※
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

public class Solution99
{
    public void RecoverTree(TreeNode root)
    {

    }

}

/**************************************************************************************************************
 *                                                                                      *
 **************************************************************************************************************/