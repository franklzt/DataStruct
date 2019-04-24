using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

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

    public class CStack
    {
        private int p_index;

        private ArrayList list;

        public CStack()
        {
            list = new ArrayList();
            p_index = -1;
        }

        public int count { get { return list.Count; } }

        public void push(Object item)
        {
            list.Add(item);
            p_index++;
        }

        public Object pop()
        {
            if (p_index < 0) return null;
            Object obj = list[p_index];
            list.RemoveAt(p_index);
            p_index--;
            return obj;
        }

        public void clear()
        {
            list.Clear();
            p_index = -1;
        }

        public Object peek()
        {
            if (p_index < 0) return null;
            return list[p_index];
        }

        public static void Test()
        {
            CStack cStack = new CStack();
            string ch;
            string word = "sees";
            bool isPalindrome = true;
            for (int x = 0; x < word.Length; x++)
            {
                cStack.push(word.Substring(x, 1));
            }
            int pos = 0;
            while (cStack.count > 0)
            {
                ch = cStack.pop().ToString();
                if (ch != word.Substring(pos, 1))
                {
                    isPalindrome = false;
                    break;
                }
                pos++;
            }
            if (isPalindrome)
            {
                Console.Write(word + " is a palindrome.");
            }
            else
            {
                Console.Write(word + " is not a palindrome.");
            }
        }

        public static bool IsNuberic(string input)
        {
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            bool flag = !validate.IsMatch(input);
            return flag;
        }

        public static void SimpleCalculator()
        {
            Stack nums = new Stack();
            Stack ops = new Stack();
            string expression = "5+10+15-20";
            Calculate(nums, ops, expression);
            Console.Write(nums.Pop());
        }

        public static void Calculate(Stack N, Stack O, string exp)
        {
            string ch, token = "";
            for (int p = 0; p < exp.Length; p++)
            {
                ch = exp.Substring(p, 1);
                if (IsNuberic(ch))
                {
                    token += ch;
                    if (ch == " " || p == (exp.Length - 1))
                    {
                        if (IsNuberic(token))
                        {
                            N.Push(token);
                        }
                    }
                    else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                    {
                        O.Push(ch);
                    }
                    if (N.Count == 2)
                    {
                        Compute(N, O);
                    }
                }
            }
        }

        public static void Compute(Stack N, Stack O)
        {
            int opera, operb;
            string oper;
            opera = Convert.ToInt32(N.Pop());
            operb = Convert.ToInt32(N.Pop());
            oper = Convert.ToString(O.Pop());
            switch (oper)
            {
                case "+":
                    N.Push(opera + operb);
                    break;
                case "-":
                    N.Push(opera - operb);
                    break;
                case "*":
                    N.Push(opera * operb);
                    break;
                case "/":
                    N.Push(opera / operb);
                    break;
            }
        }
    }



    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public void DisplayNode()
        {
            Console.Write(Data + " ");
        }
    }

    public class BinarySearchTree
    {
        public Node Root;
        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int newItem)
        {
            Node newNode = new Node();
            newNode.Data = newItem;
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                Node current = Root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (newItem < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public void InOrder(Node newRoot)
        {
            if (!(newRoot == null))
            {
                InOrder(newRoot.Left);
                newRoot.DisplayNode();
                InOrder(newRoot.Right);
            }
        }

        public void PreOrder(Node newRoot)
        {
            if (!(newRoot == null))
            {
                newRoot.DisplayNode();
                PreOrder(newRoot.Left);
                PreOrder(newRoot.Right);
            }
        }

        public void PostOrder(Node newRoot)
        {
            if (!(newRoot == null))
            {
                PostOrder(newRoot.Left);
                PostOrder(newRoot.Right);
                newRoot.DisplayNode();
            }
        }

        public int FindMin()
        {
            Node current = Root;
            while (!(current.Left == null))
            {
                current = current.Left;
            }
            return current.Data;
        }

        public int FindMax()
        {
            Node current = Root;
            while (!(current.Right == null))
            {
                current = current.Right;
            }
            return current.Data;
        }

        public Node FindKey(int key)
        {
            Node current = Root;

            while (current.Data != key)
            {
                if (key < current.Data)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                if (current == null)
                {
                    return null;
                }
            }

            return current;
        }


        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.Right;
            while(!(current == null))
            {
                successorParent = current;
                successor = current;
                current = current.Left;
            }

            if (!(successor == delNode.Right))
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }
            return successor;
        }



        public class SortHelper
        {

           public void Test()
            {
                int[] array = { 49, 38, 65, 97, 76, 13, 27 };
                QuickSort(array, 0, array.Length - 1);
            }

            private static int sortUnit(int[] array, int low, int high)
            {
                int key = array[low];
                while (low < high)
                {
                    /*从后向前搜索比key小的值*/
                    while (array[high] >= key && high > low)
                        --high;
                    /*比key小的放左边*/
                    array[low] = array[high];
                    /*从前向后搜索比key大的值，比key大的放右边*/
                    while (array[low] <= key && high > low)
                        ++low;
                    /*比key大的放右边*/
                    array[high] = array[low];
                }
                /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
                array[low] = key;
                foreach (int i in array)
                {
                    Console.Write("{0}\t", i);
                }
                Console.WriteLine();
                return high;
            }

            /**快速排序 
                *@paramarry 
                *@return */
            public static void QuickSort(int[] array, int low, int high)
            {
                if (low >= high)
                    return;
                /*完成一次单元排序*/
                int index = sortUnit(array, low, high);
                /*对左边单元进行排序*/
                QuickSort(array, low, index - 1);
                /*对右边单元进行排序*/
                QuickSort(array, index + 1, high);
            }


            public void ShellSort(int[] Elements )
            {
                int inner, temp;
                int h = 1;
                int numelements = Elements.Length;
                while(h <= numelements / 3)
                {
                    h = h * 3 + 1;
                    while(h > 0)
                    {
                        for (int outer = h; outer < numelements - 1; outer++)
                        {
                            temp = Elements[outer];
                            inner = outer;
                            while((inner > h -1) && Elements[inner -h] >= temp)
                            {
                                Elements[inner] = Elements[inner - 1];
                                inner -= h;
                            }
                            Elements[inner] = temp;
                        }
                    }
                }
                h = (h - 1) / 3;
            }
        }


        public bool Delete(int key)
        {
            Node current = Root;
            Node parent = Root;

            bool isLeftChild = true;

            while (current.Data != key)
            {
                parent = current;
                if (key < current.Data)
                {
                    isLeftChild = true;
                    current = current.Right;
                }
                else
                {
                    isLeftChild = false;
                    current = current.Right;
                }
                if (current == null)
                {
                    return false;
                }
            }

            if (current.Left == null && current.Right == null)
            {
                if (current == Root)
                {
                    Root = null;
                }
                else if (isLeftChild)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (current.Right == null)
            {
                if (current == Root)
                {
                    Root = current.Left;
                }
                else if (isLeftChild)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            else if (current.Left == null)
            {
                if (current == Root)
                {
                    Root = current.Right;
                }
                else if (isLeftChild)
                {
                    parent.Left = parent.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }

            }
            else
            {
                Node successor = GetSuccessor(current);
                if(current == Root)
                {
                    Root = successor;
                }
                else if(isLeftChild)
                {
                    parent.Left = successor;
                }
                else
                {
                    parent.Right = successor;
                }
                successor.Left = current.Left;
            }
            return true;
        }

    }

}


