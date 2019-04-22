using System;
using System.Collections;
using System.Diagnostics;

namespace DataStruct
{
    public class Chapter1
    {
        public void Test()
        {
            TimeMeasure timeMeasure = new TimeMeasure();
            timeMeasure.Start();
            int[] numbs = new int[100000];
            BuildArray(numbs);
            DisplayNums(numbs);
            timeMeasure.End();


            string[] testNames = new string[] { "One ", "two ", "3 " };
            testNames.SetValue("newValue", 0);

            foreach (var item in testNames)
            {
                Console.Write(item);
            }
        }


        void BuildArray(int[] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length; i++)
            {
                arr[i] = i;
            }
        }

        void DisplayNums(int[] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0}  ", arr[i]));
            }
        }
    }

    public class SwapHelp
    {
        public static void Swap<T>(ref T value1, ref T value2)
        {
            T temp;
            temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }

    public class TimeMeasure
    {
        TimeSpan startTime;
        TimeSpan duration;


        public TimeMeasure()
        {
            startTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }


        public void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }

        public void End()
        {
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startTime);
            Console.Write(string.Format("TimeReslut: {0}", duration));
        }
    }

    public class Collection : CollectionBase
    {
        public void Add(Object item)
        {
            InnerList.Add(item);
        }

        public void Remove(Object item)
        {
            InnerList.Remove(item);
        }

        public new void Clear()
        {
            InnerList.Clear();
        }

        public new int Count()
        {
            return InnerList.Count;
        }

        public bool Insert(int index, Object item)
        {
            if (index < 0) return false;
            InnerList.Insert(index, item);
            return true;
        }

        public bool Contains(Object item)
        {
            return InnerList.Contains(item);
        }

        public int IndexOf(Object item)
        {
            return InnerList.IndexOf(item);
        }

        public new void RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }
    }

    public class CArray
    {
        private int[] arr;
        private int upper;
        private int numElements;

        public CArray(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }

        public void Insert(int item)
        {
            if (numElements >= upper)
            {
                return;
            }
            arr[numElements] = item;
            numElements++;
        }

        public void DisplayElements()
        {
            string log = "";
            for (int i = 0; i < upper; i++)
            {
                log += arr[i].ToString() + " ";
            }

            Console.Write(log + "\n");
        }

        public void Clear()
        {
            for (int i = 0; i < upper; i++)
            {
                arr[i] = 0;
            }
            numElements = 0;
        }

        public static void Test()
        {
            CArray numbs = new CArray(50);

            Random random = new Random(100);

            for (int i = 0; i < 49; i++)
            {
                int value = (int)(random.NextDouble() * 100);
                numbs.Insert(value);
            }
            numbs.DisplayElements();

            numbs.BubbleSort();
            numbs.DisplayElements();
        }

        public void BubbleSort()
        {
            int temp;
            for (int outer = upper; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    if (arr[inner] > arr[inner + 1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                    }
                }
            }
        }

        public void SelectionSort()
        {
            int min, temp;
            for (int outer = 0; outer <= upper; outer++)
            {
                min = outer;
                for (int inner = outer + 1; inner <= upper; inner++)
                {
                    if (arr[inner] < arr[min])
                    {
                        min = inner;
                    }
                    temp = arr[outer];
                    arr[outer] = arr[min];
                    arr[min] = temp;
                }
            }
        }

        public void InsertionSort()
        {
            int inner, temp;
            for (int outer = 1; outer <= upper; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
            }
        }

        public int SeqSearch(int value)
        {
            for (int i = 0; i <= upper; i++)
            {
                if (value == arr[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindMin(int[] minArray)
        {
            int min = minArray[0];
            int minLength = minArray.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (minArray[i] < min)
                {
                    min = minArray[i];
                }
            }
            return min;
        }

        public static int FindMax(int[] maxArray)
        {
            int max = maxArray[0];
            int minLength = maxArray.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (maxArray[i] > max)
                {
                    max = maxArray[i];
                }
            }
            return max;
        }

        public static void Swap(int[] array, ref int source, ref int dest)
        {
            int temp = array[source];
            array[source] = array[dest];
            array[dest] = temp;
        }

        public static int SeqSearchFast(int[] searchArray, int value)
        {
            for (int index = 0; index < searchArray.Length; index++)
            {
                if (searchArray[index] == value && index > (searchArray.Length * 0.2))
                {
                    int sourceIndex = index;
                    int destIndex = index - 1;
                    Swap(searchArray, ref sourceIndex, ref destIndex);
                    return index;
                }
                else if (searchArray[index] == value)
                {
                    return index;
                }
            }
            return -1;
        }

        public int BinarySearch(int[] searchArray, int value)
        {
            int upperBound, lowerBound, mid;
            upperBound = searchArray.Length - 1;
            lowerBound = 0;
            while (lowerBound <= upperBound)
            {
                mid = (upperBound + lowerBound) / 2;
                if (searchArray[mid] == value)
                {
                    return mid;
                }
                else if (value < searchArray[mid])
                {
                    upperBound = mid - 1;
                }
                else
                {
                    lowerBound = mid + 1;
                }
            }
            return -1;
        }
    }
}


