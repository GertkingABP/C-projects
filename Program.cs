using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int[] arr;
    static int count;
    static int k;

    public static int CountZeroChains(int[] arr, int k, int numThreads)
    {
        int count = 0;
        int len = arr.Length;
        int chunkSize = len / numThreads;

        object lockObj = new object();
        Thread[] threads = new Thread[numThreads];

        for (int i = 0; i < numThreads; i++)
        {
            int start = i * chunkSize;
            int end = (i == numThreads - 1) ? len : (i + 1) * chunkSize;

            threads[i] = new Thread(() =>
            {
                int localCount = 0;

                for (int j = start; j < end - k; j++)
                {
                    bool isChain = true; //является ли текущая последовательность цепочкой из k нулей

                    for (int l = j; l < j + k; l++)
                    {
                        if (arr[l] != 0)
                        {
                            isChain = false;
                            break;
                        }
                    }

                    if (isChain)
                        localCount++;
                }

                lock (lockObj)

                    count += localCount;
            });

            threads[i].Start();
        }

        for (int i = 0; i < numThreads; i++)
            threads[i].Join();

        return count;
    }

    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        int t = 1;
        k = 3;
        int thread_num = 1;
        //arr = new int[] { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1 };
        arr = new int[180180000];
        Random rand = new Random();

        while (t <= 10)
        {
            Console.WriteLine("\n---------------------------------------\nИтерация {0}", t);
            for (int x = 0; x < arr.Length; x++)
            {
                arr[x] = rand.Next(4);
            }

            for (int i = 0; i < 10; i++)//первые 10 чисел
                Console.WriteLine("{0} ", arr[i]) ;

            while (thread_num <= 16)
            {

                stopwatch.Start();
                count = CountZeroChains(arr, k, thread_num);
                stopwatch.Stop();

                Console.WriteLine("\n\nРабота в {0} поток(е/ах):", thread_num);
                Console.WriteLine("\nКоличество цепочек из {0} нулей: {1}", k, count);
                TimeSpan ts = stopwatch.Elapsed;

                Console.WriteLine("\nВремя вычислений = {0:00}:{1:00}:{2:00}.{3}",
                                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

                thread_num++;
                stopwatch.Reset();
            }

            t++;
            thread_num = 1;
        }

        Console.ReadKey();
    }
}