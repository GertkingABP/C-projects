using System.Diagnostics;
using System.Threading;

int ComputeLevenshteinDistance(string s, string t)
{
    int m = s.Length;
    int n = t.Length;
    int[,] d = new int[m + 1, n + 1];

    if (m == 0)
        return n;

    if (n == 0)
        return m;

    for (int i = 0; i <= m; i++)
        d[i, 0] = i;

    for (int j = 0; j <= n; j++)
        d[0, j] = j;

    for (int j = 1; j <= n; j++)
    {
        for (int i = 1; i <= m; i++)
        {
            int cost = s[i - 1] == t[j - 1] ? 0 : 1;
            d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
        }
    }

    return d[m, n];
}

string text = File.ReadAllText("text4.txt");
string pattern = File.ReadAllText("search.txt");
Stopwatch stopwatch = new Stopwatch();
int numThreads = 1;
int t = 1;

while (t <= 10)
{
    Console.WriteLine("\n---------------------------------------\nИтерация {0}", t);
    while (numThreads <= 16)
    {
        Console.WriteLine("\n\n\nРабота в {0} поток(е/ах):", numThreads);
        int chunkSize = text.Length / numThreads;
        List<string> chunks = new List<string>();

        for (int i = 0; i < numThreads; i++)
        {
            int start = i * chunkSize;
            int end = (i + 1) * chunkSize;

            if (i == numThreads - 1)
                end = text.Length;

            chunks.Add(text.Substring(start, end - start));
        }

        string closestMatch = null;
        int closestMatchDistance = int.MaxValue;
        object lockObj = new object();
        List<Thread> threads = new List<Thread>();

        stopwatch.Start();

        Parallel.ForEach(chunks, chunk =>
        {
            int startIndex = text.IndexOf(chunk);
            int endIndex = startIndex + chunk.Length;
            for (int i = startIndex; i < endIndex - pattern.Length; i++)
            {
                string substring = text.Substring(i, pattern.Length);
                int distance = ComputeLevenshteinDistance(substring, pattern);

                if (distance < closestMatchDistance)
                {
                    lock (lockObj)
                    {
                        if (distance < closestMatchDistance)
                        { 
                            closestMatch = substring;
                            closestMatchDistance = distance;
                        }
                    }
                }
            }
        });

        stopwatch.Stop();

        TimeSpan ts = stopwatch.Elapsed;
        Console.WriteLine("\nСлучай с Parallel.ForEach:");
        Console.WriteLine("\nНаиболее похожая строка: {0}", closestMatch);
        Console.WriteLine("\nНаименьшее расстояние Левенштейна: {0}", closestMatchDistance);
        Console.WriteLine("\nВремя вычислений = {000:00}.{1}",
                                ts.Seconds, ts.Milliseconds);
        stopwatch.Reset();
        numThreads++;
    }

    numThreads = 1;
    t++;
}