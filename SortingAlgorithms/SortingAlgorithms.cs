namespace Algorithms.SortingAlgorithms;

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
}