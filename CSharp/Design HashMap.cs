﻿//Source  : https://leetcode.com/problems/design-hashmap/
//Author  : Xinruo Shi
//Date    : 2019-08-18
//Language: C#

/*******************************************************************************************************************************
 * 
 * Design a HashMap without using any built-in hash table libraries.
 * To be specific, your design should include these functions:
 *      put(key, value) : Insert a (key, value) pair into the HashMap. If the value already exists in the HashMap, update the value.
 *      get(key): Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
 *      remove(key) : Remove the mapping for the value key if this map contains the mapping for the key.
 *      
 * MyHashMap hashMap = new MyHashMap();
 * hashMap.put(1, 1);          
 * hashMap.put(2, 2);         
 * hashMap.get(1);            // returns 1
 * hashMap.get(3);            // returns -1 (not found)
 * hashMap.put(2, 1);          // update the existing value
 * hashMap.get(2);            // returns 1 
 * hashMap.remove(2);          // remove the mapping for 2
 * hashMap.get(2);            // returns -1 (not found) 
 * 
 * Note:
 *      All keys and values will be in the range of [0, 1000000].
 *      The number of operations will be in the range of [1, 10000].
 *      Please do not use the built-in HashMap library.
 * ※
 *******************************************************************************************************************************/
//class 706

// --------------- O(1) 267ms --------------- 38.4MB --------------- (97% 100%)
/*
 * this solution use array , space not good
 */
public class MyHashMap_1
{
    int[] array;

    /** Initialize your data structure here. */
    public MyHashMap_1()
    {
        array = new int[1000001];       
    }

    /** value will always be non-negative. */
    public void Put(int key, int value)
    {
        array[key] = value + 1;
    }

    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key)
    {
        return array[key]-1;
    }

    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key)
    {
        array[key] = 0;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */