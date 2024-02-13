namespace DelegatesTask
{
    public class Sorter
    {
        public static void BubbleSort<T>(T[] array, Comparison<T> compare)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (compare(array[i], array[i + 1]) > 0)
                    {
                        (array[i + 1], array[i]) = (array[i], array[i + 1]);
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
