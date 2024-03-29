﻿namespace Algorithms.SearchingAlgorithms;

public class SearchingAlgorithms
{
    public int LinearSearch(int[] array, int item)
    {
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == item) return i;
        }

        return -1;
    }

    public int BinarySearchIterative(int[] array, int item)
    {
        var left = 0;
        var right = array.Length - 1;
        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (array[middle] > item) right = middle - 1;
            else if (array[middle] < item) left = middle + 1;
            else return middle;
        }

        return array[left] == item ? left : -1;
    }

    public int BinarySearchRecursive(int[] array, int item)
    {
        return BinarySearchRecursive(array, item, 0, array.Length - 1);
    }

    private int BinarySearchRecursive(int[] array, int item, int start, int end)
    {
        if (start >= end) return array[end] == item ? start : -1;
        int middle = (start + end) / 2;
        if (array[middle] > item) return BinarySearchRecursive(array, item, start, middle - 1);
        if (array[middle] < item) return BinarySearchRecursive(array, item, middle + 1, end);
        return middle;
    }

    public int TernarySearch(int[] array, int item)
    {
        return TernarySearch(array, item, 0, array.Length - 1);
    }

    private int TernarySearch(int[] array, int item, int start, int end)
    {
        if (start > end) return -1;
        var partSize = (end - start) / 3;
        var firstMiddle = start + partSize;
        var secondMiddle = end - partSize;
        if (array[firstMiddle] == item) return firstMiddle;
        if (array[secondMiddle] == item) return secondMiddle;
        if (item > array[secondMiddle]) return TernarySearch(array, item, secondMiddle + 1, end);
        if (item < array[firstMiddle]) return TernarySearch(array, item, start, firstMiddle - 1);
        return TernarySearch(array, item, firstMiddle + 1, secondMiddle - 1);
    }

    public int JumpSearch(int[] array, int item)
    {
        var blockSize = (int) Math.Sqrt(array.Length);
        var start = 0;
        var next = blockSize;
        while (start < array.Length)
        {
            if (array[next - 1] >= item)
            {
                for (int i = next - 1; i >= 0; i--)
                {
                    if (array[i] == item)
                        return i;
                }

                return -1;
            }
            else
            {
                start += blockSize;
                next += blockSize;
                if (next > array.Length) next = array.Length;
            }
        }

        return -1;
    }

    public int ExponentialSearch(int[] array, int item)
    {
        var bound = 1;
        while (bound < array.Length && array[bound] < item)
        {
            bound *= 2;
        }

        var start = bound / 2;
        var end = bound >= array.Length ? array.Length - 1 : bound;
        return BinarySearchRecursive(array, item, start, end);
    }
}