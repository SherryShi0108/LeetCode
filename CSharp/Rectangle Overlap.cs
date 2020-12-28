//Source  : https://leetcode.com/problems/rectangle-overlap/
//Author  : Xinruo Shi
//Date    : 2019-09-17
//Language: C#

/*******************************************************************************************************************************
 * 
 * A rectangle is represented as a list [x1, y1, x2, y2], where (x1, y1) are the coordinates of its bottom-left corner, 
 * and (x2, y2) are the coordinates of its top-right corner.
 * Two rectangles overlap if the area of their intersection is positive.  
 * To be clear, two rectangles that only touch at the corner or edges do not overlap.
 * Given two (axis-aligned) rectangles, return whether they overlap.
 * 
 * Input: rec1 = [0,0,2,2], rec2 = [1,1,3,3]
 * Output: true
 * 
 * Input: rec1 = [0,0,1,1], rec2 = [1,0,2,1]
 * Output: false
 * 
 * Notes:
 *      rect1.length == 4
 *      rect2.length == 4
 *      -109 <= rec1[i], rec2[i] <= 109
 *      rec1[0] <= rec1[2] and rec1[1] <= rec1[3]
 *      rec2[0] <= rec2[2] and rec2[1] <= rec2[3]
 * 
 *******************************************************************************************************************************/

public class Solution836
{
    // --------------- O(1) 84ms --------------- O(1) 25MB --------------- (95% 10%) ※
    /*
     * Amazing Solution : 1D to 2D
     * Need check whether this is a valid rectangle 
     */
    public bool IsRectangleOverlap_1(int[] rec1, int[] rec2)
    {
        if (rec1[0] >= rec1[2] || rec1[1] >= rec1[3] || rec2[0] >= rec2[2] || rec2[1] >= rec2[3])
        {
            return false;
        }

        return rec1[0] < rec2[2] && rec2[0] < rec1[2] 
            && rec1[1] < rec2[3] && rec2[1] < rec1[3];
    }

    // --------------- O(1) 92ms --------------- O(1) 24MB --------------- (34% 84%) 
    /*
     * Width > 0 ; Height > 0
     */
    public bool IsRectangleOverlap_2(int[] rec1, int[] rec2)
    {
        int min1 = rec1[2] < rec2[2] ? rec1[2] : rec2[2];
        int max1 = rec1[0] > rec2[0] ? rec1[0] : rec2[0];
        int min2 = rec1[3] < rec2[3] ? rec1[3] : rec2[3];
        int max2 = rec1[1] > rec2[1] ? rec1[1] : rec2[1];

        return min1 > max1 &&  // width > 0
               min2 > max2;  // height > 0
    }
}
/**************************************************************************************************************
 * IsRectangleOverlap_1  IsRectangleOverlap_2                                                                 *
 **************************************************************************************************************/