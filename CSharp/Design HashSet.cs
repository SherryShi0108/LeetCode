﻿//Source  : https://leetcode.com/problems/design-hashset/
//Author  : Xinruo Shi
//Date    : 2019-08-17
//Language: C#

/*******************************************************************************************************************************
 * 
 * Design a HashSet without using any built-in hash table libraries.
 * To be specific, your design should include these functions:
 *      add(value): Insert a value into the HashSet. 
 *      contains(value) : Return whether the value exists in the HashSet or not.
 *      remove(value): Remove a value in the HashSet. If the value does not exist in the HashSet, do nothing.
 *      
 * MyHashSet hashSet = new MyHashSet();
 * hashSet.add(1);         
 * hashSet.add(2);         
 * hashSet.contains(1);    // returns true
 * hashSet.contains(3);    // returns false (not found)
 * hashSet.add(2);          
 * hashSet.contains(2);    // returns true
 * hashSet.remove(2);          
 * hashSet.contains(2);    // returns false (already removed)
 * 
 * Note:
 *      All values will be in the range of [0, 1000000].
 *      The number of operations will be in the range of [1, 10000].
 *      Please do not use the built-in HashSet library.
 * ※
 *******************************************************************************************************************************/
//class 705
/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */

// --------------- O(1) 256ms --------------- 41.3MB --------------- (67% 100%)
/*
 * this solution use array , this is not good
 * use int(0,1) or bool(false,true) also right
 */
public class MyHashSet_1
{
    int[] array;
    /** Initialize your data structure here. */
    public MyHashSet_1()
    {
        array = new int[1000001];
    }

    public void Add(int key)
    {
        array[key] = 1;
    }

    public void Remove(int key)
    {
        array[key] = 0;
    }

    /** Returns true if this set contains the specified element */
    public bool Contains(int key)
    {
        return array[key]==1;
    }
}

// --------------- O(1) 252ms --------------- 49.2MB --------------- (70% 100%)
/*
 * this solution use array[][] , use bucket
 */
public class MyHashSet_2
{
    /** Initialize your data structure here. */
    private int buckets = 1000;
    private int perBucket = 1001;
    private bool[][] table;

    public MyHashSet_2()
    {
        table = new bool[buckets][];
    }

    public void Add(int key)
    {
        if (table[key%1000] == null)
        {
            table[key % 1000] =new bool[perBucket];
        }

        table[key % 1000][key / 1000] = true;
    }

    public void Remove(int key)
    {
        if (table[key % 1000] != null)
        {
            table[key % 1000][key / 1000] = false;
        }
    }

    /** Returns true if this set contains the specified element */
    public bool Contains(int key)
    {
        return (table[key % 1000] != null && table[key % 1000][key / 1000]);
    }
}



