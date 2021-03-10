//Source  : https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
//Author  : Xinruo Shi
//Date    : 2020-11-29
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given the root of a Binary Search Tree and a target number k, return true if there exist two elements in the BST
 * such that their sum is equal to the given target.
 *
 * Input:            5
 *                  / \
 *                 3   6
 *                / \   \
 *               2  4    7
 * root = [5,3,6,2,4,null,7], k = 9
 * Output: true
 *
 * Input:            5
 *                  / \
 *                 3   6
 *                / \   \
 *               2  4    7
 * root = [5,3,6,2,4,null,7], k = 28
 * Output: false
 *
 * Input: root = [2,1,3], k = 4
 * Output: true
 *
 * Input: root = [2,1,3], k = 1
 * Output: false
 *
 * Input: root = [2,1,3], k = 3
 * Output: true
 *
 * Constraints:
 *      The number of nodes in the tree is in the range [1, 104].
 *      -104 <= Node.val <= 104
 *      root is guaranteed to be a valid binary search tree.
 *      -105 <= k <= 105
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;

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

public class Solution653
{
    // --------------- O(n) 200ms --------------- O(n) 31MB --------------- (8% 93%) 
    /*
     *  Using HashSet
     */
    public bool FindTarget_1(TreeNode root, int k)
    {
        HashSet<int> H = new HashSet<int>();
        return FindTest(root, k, H);
    }

    private bool FindTest(TreeNode root, int k, HashSet<int> h)
    {
        if (root == null) return false;
        if (h.Contains(k - root.val)) return true;

        h.Add(root.val);
        return FindTest(root.left, k, h) || FindTest(root.right, k, h);
    }

    // --------------- O(n) 180ms --------------- O(n) 31MB --------------- (11% 88%) ※
    /*
     *  Improve 1
     */
    public bool FindTarget_1_2(TreeNode root, int k)
    {
        if (root == null) return false;

        if (Hash.Contains(k - root.val)) return true;

        Hash.Add(root.val);
        return FindTarget_1_2(root.left, k) || FindTarget_1_2(root.right, k);
    }

    private HashSet<int> Hash = new HashSet<int>();

    // --------------- O(n) 148ms --------------- O(n) 31MB --------------- (21% 99%) 
    /*
     *  Using BFS
     */
    public bool FindTarget_2(TreeNode root, int k)
    {
        HashSet<int> H = new HashSet<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            if (queue.Peek() != null)
            {
                TreeNode node = queue.Dequeue();
                if (H.Contains(k - node.val))
                {
                    return true;
                }

                H.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else
            {
                queue.Dequeue();
            }
        }

        return false;
    }

    // --------------- O(n) 116ms --------------- O(n) 32MB --------------- (82% 46%) 
    public bool FindTarget_3(TreeNode root, int k)
    {
        List<int> list = new List<int>();
        inorder(root, list);

        int m = 0;
        int n = list.Count - 1;
        while (m<n)
        {
            int sum = list[m] + list[n];
            if (sum == k) return true;

            if (sum > k)
            {
                n--;
            }
            else
            {
                m++;
            }
        }

        return false;
    }

    private void inorder(TreeNode root, List<int> list)
    {
        if (root == null) return;
        inorder(root.left,list);
        list.Add(root.val);
        inorder(root.right, list);
    }
}
/**************************************************************************************************************
 * FindTarget_1  FindTarget_2  FindTarget_3                                                                   *
 **************************************************************************************************************/