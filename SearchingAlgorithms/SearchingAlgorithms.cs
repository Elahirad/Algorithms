namespace Algorithms.SearchingAlgorithms;

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
        if (start > end) return array[start] == item ? start : -1;
        int middle = (start + end) / 2;
        if (array[middle] > item) return BinarySearchRecursive(array, item, start, middle - 1);
        if (array[middle] < item) return BinarySearchRecursive(array, item, middle + 1, end);
        return middle;
    }
}