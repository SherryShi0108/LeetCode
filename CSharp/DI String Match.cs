//Source  : https://leetcode.com/problems/di-string-match/
//Author  : Xinruo Shi
//Date    : 2019-09-21
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a string S that only contains "I" (increase) or "D" (decrease), let N = S.length.
 * Return any permutation A of [0, 1, ..., N] such that for all i = 0, ..., N-1:
 * If S[i] == "I", then A[i] < A[i+1]
 * If S[i] == "D", then A[i] > A[i+1]
 * 
 * Input: "IDID"
 * Output: [0,4,1,3,2]
 * 
 * Input: "III"
 * Output: [0,1,2,3]
 * 
 * Input: "DDI"
 * Output: [3,2,0,1]
 * 
 * Note: 1 <= S.length <= 10000
 *       S only contains characters "I" or "D".
 * 
 *******************************************************************************************************************************/

public class Solution942
{
    // --------------- O(n) 264ms --------------- 33.4MB --------------- (45% 50%)
    public int[] DiStringMatch_1(string S)
    {
        int L = 0;int H = S.Length;
        int[] result = new int[S.Length + 1];

        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == 'I')
            {
                result[i] = L++;
            }
            else
            {
                result[i] = H--;
            }
            /* result[i] = S[i] == 'I' ? L++ : H--; */
        }
        result[S.Length] = L;

        return result;
    }
    
    // --------------- O(n) 224ms --------------- 36MB --------------- (99% 6%) ※
    public int[] DiStringMatch_2(string S)
    {
        int i = 0;
        int j = S.Length; 

        List<int> list = new List<int>();
        foreach (char c in S)
        {
            if (c == 'I')
            {
                list.Add(i++);
            }
            else if (c == 'D')
            {
                list.Add(j--);
            }
        }

        list.Add(i);
        return list.ToArray();
    }
}
/**************************************************************************************************************
 * DiStringMatch_2                                                                                            *
 **************************************************************************************************************/
