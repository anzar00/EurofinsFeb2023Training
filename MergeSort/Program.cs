using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, n = 0;

            Console.WriteLine("Enter N: ");
            n = Convert.ToInt32(Console.ReadLine());
            
            int[] arr = new int[n];
            
            Console.WriteLine("Enter array elements: ");
            for (i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            MergeSort(arr, 0, n - 1);

            Console.WriteLine("Sorted array: ");

            for (i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.ReadKey();
        }

        static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        static void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[100];
            int[] R = new int[100];

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }

            for (j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            i = 0;
            j = 0;
            k = l;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
