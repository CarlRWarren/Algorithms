using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {
        public static void BubbleSort(T[] arr)
        {
            int length = arr.Length;
            for(int i=0; i<length-1; i++)
            {
                for(int j = 0; j<length-i-1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1])==1)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(T[] arr)
        {
            int length = arr.Length;
            for (int i = 1; i < length; ++i)
            {
                T key = arr[i];
                int j = i - 1;
                
                while (j >= 0 && arr[j].CompareTo(key)==1)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        public static void SelectionSort(T[] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j].CompareTo(arr[min_idx])==-1)
                    {
                        min_idx = j;
                    }
                }
                T temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
