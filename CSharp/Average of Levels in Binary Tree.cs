//Source  : https://leetcode.com/problems/average-of-levels-in-binary-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-27
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty binary tree, return the average value of the nodes on each level in the form of an array.
 *
 * Input:
 *              3
 *             / \
 *            9  20
 *              /  \
 *             15   7
 * Output: [3, 14.5, 11]
 * Explanation:
 *      The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on level 2 is 11. Hence return [3, 14.5, 11].
 *
 * Note: The range of node's value is in the range of 32-bit signed integer.
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

public class Solution637
{
    // --------------- O(n) 252ms --------------- O(h) 34MB --------------- (59% 93%)
    /*
     * Using Depth First Search
     */
    public IList<double> AverageOfLevels_1(TreeNode root)
    {
        List<int> count = new List<int>();
        List<double> sum = new List<double>();
        Average(root, 0, sum, count);
        for (int i = 0; i < sum.Count; i++)
        {
            sum[i] = sum[i] / count[i];
        }

        return sum;
    }

    private void Average(TreeNode node, int i, List<double> sum, List<int> count)
    {
        if (node == null) return;
        if (i < sum.Count)
        {
            sum[i] = sum[i] + node.val;
            count[i] = count[i] + 1;
        }
        else
        {
            sum.Add(node.val * 1.0);
            count.Add(1);
        }

        Average(node.left, i + 1, sum, count);
        Average(node.right, i + 1, sum, count);
    }

    // --------------- O(n) 252ms --------------- O(h) 35MB --------------- (59% 23%) 
    /*
     * Using Breadth First Search
     */
    public IList<double> AverageOfLevels_2(TreeNode root)
    {
        if (root == null) return new List<double>();

        List<double> result = new List<double>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count>0)
        {
            long sum = 0;
            long count = 0;

            Queue<TreeNode> temp = new Queue<TreeNode>();
            while (queue.Count>0)
            {
                TreeNode n = queue.Dequeue();
                sum += n.val;
                count++;
                if (n.left != null)
                {
                    temp.Enqueue(n.left);
                }
                if (n.right != null)
                {
                    temp.Enqueue(n.right);
                }
            }

            queue = temp;
            result.Add(sum * 1.0 / count);
        }

        return result;
    }

    // --------------- O(n) 256ms --------------- O(m) 34MB --------------- (36% 93%) ※
    /*
     * using n to avoid new Queue<TreeNode>
     */
    public IList<double> AverageOfLevels_2_2(TreeNode root)
    {
        if (root == null) return new List<double>();

        List<double> result = new List<double>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            long sum = 0;
            long count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                TreeNode n = queue.Dequeue();
                sum += n.val;

                if (n.left != null)
                {
                    queue.Enqueue(n.left);
                }
                if (n.right != null)
                {
                    queue.Enqueue(n.right);
                }
            }
           
            result.Add(sum * 1.0 / count);
        }

        return result;
    }
}
/**************************************************************************************************************
 * AverageOfLevels_1  AverageOfLevels_2 / AverageOfLevels_2_2                                                 *
 **************************************************************************************************************/