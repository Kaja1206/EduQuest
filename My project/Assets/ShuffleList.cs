using System.Collections.Generic;
using UnityEngine;

public static class ShuffleList
{
    public static List<T> ShuffleListItems<T>(List<T> inputList)
    {
        List<T> shuffledList = new List<T>(inputList);
        int n = shuffledList.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            (shuffledList[i], shuffledList[rand]) = (shuffledList[rand], shuffledList[i]); // Swap elements
        }
        return shuffledList;
    }
}



