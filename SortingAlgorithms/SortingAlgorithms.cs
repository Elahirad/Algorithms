﻿namespace Algorithms.SortingAlgorithms;

public class SortingAlgorithms
{
    public void BubbleSort(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            bool sorted = true;
            for (int j = 1; j < list.Count - i; j++)
            {
                if (list[j - 1] > list[j])
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                    sorted = false;
                }
            }

            if (sorted) return;
        }
    }

    public void SelectionSort(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int minIndex = i;
            for (int j = i; j < list.Count; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }

            (list[minIndex], list[i]) = (list[i], list[minIndex]);
        }
    }

    public void InsertionSort(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            var takenItem = list[i];
            int j = i - 1;
            while (j >= 0 && list[j] > takenItem)
            {
                list[j + 1] = list[j];
                j--;
            }

            list[j + 1] = takenItem;
        }
    }

    public void MergeSort(List<int> list)
    {
        if (list.Count < 2) return;
        var firstHalf = new List<int>();
        var secondHalf = new List<int>();
        SliceList(list, firstHalf, secondHalf);
        MergeSort(firstHalf);
        MergeSort(secondHalf);
        MergeTwoLists(list, firstHalf, secondHalf);
    }

    private void SliceList(List<int> list, List<int> firstHalf, List<int> secondHalf)
    {
        if (list.Count == 0) return;
        int halfIndex = list.Count / 2;
        for (int i = 0; i < list.Count; i++)
        {
            if (i < halfIndex) firstHalf.Add(list[i]);
            else secondHalf.Add(list[i]);
        }
    }

    private void MergeTwoLists(List<int> list, List<int> firstHalf, List<int> secondHalf)
    {
        int firstIndex = 0, secondIndex = 0, listIndex = 0;
        while (listIndex < list.Count)
        {
            if (firstIndex >= firstHalf.Count) list[listIndex++] = secondHalf[secondIndex++];
            else if (secondIndex >= secondHalf.Count) list[listIndex++] = firstHalf[firstIndex++];
            else
            {
                if (firstHalf[firstIndex] > secondHalf[secondIndex]) list[listIndex++] = secondHalf[secondIndex++];
                else list[listIndex++] = firstHalf[firstIndex++];
            }
        }
    }

    public void QSort(int[] array)
    {
        QSort(array, array.Length - 1, 0, array.Length);
    }

    private void QSort(int[] array, int index, int from, int to)
    {
        if (from >= to) return;

        // Partitioning input array
        var pivotIndex = QSortPivoting(array, index, from, to);

        // QSorting left half
        var leftFrom = from;
        var leftTo = pivotIndex;
        var leftPivotIndex = pivotIndex - 1;
        QSort(array, leftPivotIndex, leftFrom, leftTo);

        // QSorting right half
        var rightFrom = pivotIndex + 1;
        var rightTo = to;
        var rightPivotIndex = to - 1;
        QSort(array, rightPivotIndex, rightFrom, rightTo);
    }

    private int QSortPivoting(int[] array, int index, int from, int to)
    {
        var pivot = array[index];
        int boundary = from - 1;
        int j = from;
        while (j < to)
        {
            if (array[j] < pivot)
            {
                boundary++;
                (array[boundary], array[j]) = (array[j], array[boundary]);
            }

            j++;
        }

        boundary++;
        (array[to - 1], array[boundary]) = (array[boundary], array[to - 1]);

        return boundary;
    }

    public void CountingSort(int[] array)
    {
        int max = int.MinValue;
        int i;
        for (i = 0; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }

        var countingArray = new int[max + 1];
        for (i = 0; i < array.Length; i++)
        {
            countingArray[array[i]]++;
        }

        i = 0;
        for (int j = 0; j < countingArray.Length; j++)
        {
            for (int k = 0; k < countingArray[j]; k++)
            {
                array[i] = j;
                i++;
            }
        }
    }

    public void BucketSort(int[] array, int bucketCount)
    {
        var buckets = MakingBuckets(array, bucketCount);
        var k = 0;
        for (var i = 0; i < bucketCount; i++)
        {
            var bucketArray = buckets[i].ToArray();
            QSort(bucketArray);
            foreach (var item in bucketArray)
            {
                array[k++] = item;
            }
        }
    }

    private LinkedList<int>[] MakingBuckets(int[] array, int bucketCount)
    {
        var buckets = new LinkedList<int>[bucketCount];
        for (var j = 0; j < bucketCount; j++) buckets[j] = new LinkedList<int>();
        foreach (var item in array)
        {
            buckets[item / bucketCount].AddLast(item);
        }

        return buckets;
    }
}