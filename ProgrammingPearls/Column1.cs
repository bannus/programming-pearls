using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProgrammingPearls
{
    static class Column1
    {
        static public TimeSpan SortTenMillion()
        {
            var timer = new Stopwatch();
            var list1 = Column1.UniqueRandomList(10000000, 10000000);

            timer.Start();
            Column1.MergeSort(list1);
            timer.Stop();
            return timer.Elapsed;
        }

        /// <summary>
        /// Generates k unique random numbers between 0 and [n-1]
        /// </summary>
        static public int[] UniqueRandomList(int k, int n)
        {
            var ints = new int[n];
            var output = new int[k];
            Random r = new Random();
            for (int i = 0; i < n; i++)
                ints[i] = i;
            for (int i = 0; i < k; i++)
            {
                int randomIndex = r.Next(i, n);
                Util.Swap(ref ints[i], ref ints[randomIndex]);
                output[i] = ints[i];
            }
            return output;
        }

        static public void MergeSort(int[] list)
        {
            MergeSortHelper(list, 0, list.Length - 1);
        }

        static public void Merge(int[] list, int first, int mid, int last)
        {
            int total = last - first + 1;
            int[] merged = new int[total];

            int i = first, j = mid, n = 0;
            while ((i <= mid - 1) || (j <= last))
            {
                if (i > mid - 1)
                    merged[n++] = list[j++];
                else if (j > last)
                    merged[n++] = list[i++];
                else if (list[i] < list[j])
                    merged[n++] = list[i++];
                else
                    merged[n++] = list[j++];
            }

            for (int k = 0; k < total; k++)
            {
                list[first + k] = merged[k];
            }

            return;
        }

        // [first ... mid - 1] [mid ... last]
        private static void MergeSortHelper(int[] list, int first, int last)
        {
            int n = last - first + 1;
            int mid = (n / 2) + first;
            if (n == 2)
            {
                if (list[first] > list[last])
                    Util.Swap(ref list[first], ref list[last]);
            }
            else if (n > 2)
            {
                // recursively sort each half of the list
                MergeSortHelper(list, first, mid - 1);
                MergeSortHelper(list, mid, last);

                // merge the two sorted halves
                Merge(list, first, mid, last);
            }
        }
    }
}