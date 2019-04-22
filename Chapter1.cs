using System;
using System.Collections;
using Object = System.Object;
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


            string[] testNames = new string[] {"One ","two ","3 " };
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
        public static void Swap<T>(ref T value1,ref T value2)
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
            if(numElements >= upper)
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
                    if(arr[inner] > arr[inner+1])
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
                for (int inner = outer +1; inner <= upper; inner++)
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
                while(inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
            }
        }
    }
}


