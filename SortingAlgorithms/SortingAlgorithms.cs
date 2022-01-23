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
}