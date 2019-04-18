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
        public static void MergeSort(T[] arr, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                MergeSort(arr, start, middle);
                MergeSort(arr, middle + 1, end);

                Merge(arr, start, middle, end);
            }
        }

        private static void Merge(T[] arr, int start, int mid, int end)
        {
            T[] leftArray = new T[mid - start + 1];
            T[] rightArray = new T[end - mid];

            Array.Copy(arr, start, leftArray, 0, mid - start + 1);
            Array.Copy(arr, mid + 1, rightArray, 0, end - mid);

            int i = 0;
            int j = 0;
            for (int k = start; k < end + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i].CompareTo(rightArray[j])==0|| leftArray[i].CompareTo(rightArray[j]) == -1)
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
            }
        }

        public static void QuickSort(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1) QuickSort(arr, left, pivot - 1);
                if (pivot + 1 < right) QuickSort(arr, pivot + 1, right);
            }
        }
        static public int Partition(T[] numbers, int left, int right)
        {
            T pivot = numbers[left];
            while (true)
            {
                while (numbers[left].CompareTo(pivot)==-1) left++;
                while (numbers[right].CompareTo(pivot)==1) right--;

                if (left < right)
                {
                    T temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
