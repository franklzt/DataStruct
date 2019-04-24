using System;

namespace DataStruct
{
    public class BasicID
    {
        private int[] minList = new int[]{18,4,8,9,16,1,14,7,19,3,0,5,2,11,6};


        public int[] BubbleSort(int[] arr)
        {
            int temp;
            for (int outer = arr.Length -1; outer >= 1; outer--)
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

            return arr;
        }


        public static void Test()
        {
            BasicID basicID = new BasicID();
            int totalSize = 1000000;
            int[] tempIndex = new int[totalSize];
            Random random = new Random();
            for (int i = 0; i < totalSize; i++)
            {
                int value = (int)(random.NextDouble() * totalSize);
                tempIndex[i] = Math.Abs(value);
            }
            int min = basicID.MinFreeList(tempIndex);
            Console.Write("  The min is:  " + min);
        }

        public int MinFree(int[] list)
        {
            list = BubbleSort(list);
            int minValue = 0;
            int index = 0;
            int length = minList.Length;


            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + "  ");
            }


            while(index < length)
            {
                if(minValue != list[index])
                {
                    return minValue;
                }
                else
                {
                    minValue++;
                }
                index++;
            }
            return -1;
        }


        public int MinFreeList(int[] list)
        {
            int max = 0;

            for (int i = 0; i < list.Length; i++)
            {
                if(list[i] > max)
                {
                    max = list[i];
                }
            }

            bool[] temp = new bool[max + 1];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = false;
            }

            for (int i = 0; i < temp.Length ; i++)
            {
                if(i < list.Length)
                {
                    int tempIndex = list[i];
                    temp[tempIndex] = true;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i]) return i;
            }
            return -1;
        }


        void Swap(int[] swapArray,int x,int y)
        {
            int temp = swapArray[x];
            swapArray[x] = swapArray[y];
            swapArray[y] = temp;
        }

        public int MinFreeDevide(int[] list)
        {
            int min = 0;
            int index = 0;
            while(true)
            {
                if(list[index] > min)
                {
                    min++;
                }
                else
                {
                    min--;
                }
                index++;
                if(index >= list.Length)
                {
                    break;
                }
            }
            return min;
        }

    }
}



