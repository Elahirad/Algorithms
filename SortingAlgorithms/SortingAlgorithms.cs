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
}