//Source  : https://leetcode.com/problems/validate-binary-search-tree/
//Author  : Xinruo Shi
//Date    : 2022-05-01
//Language: C#

/*******************************************************************************************************************************
    Given the root of a binary tree, determine if it is a valid binary search tree (BST).

    A valid BST is defined as follows:
        The left subtree of a node contains only nodes with keys less than the node's key.
        The right subtree of a node contains only nodes with keys greater than the node's key.
        Both the left and right subtrees must also be binary search trees.

    Input: root = [2,1,3]
    Output: true

    Input: root = [5,1,4,null,null,3,6]
    Output: false
    Explanation: The root node's value is 5 but its right child's value is 4.

    Constraints:
        The number of nodes in the tree is in the range [1, 104].
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

public class Solution98
{
    public bool IsValidBST(TreeNode root)
    {

    }

}

/**************************************************************************************************************
 *                                                                                      *
 **************************************************************************************************************/