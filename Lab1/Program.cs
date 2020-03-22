using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laborator1
{
    public static class Prime
    {
        public static int FindPrime(int n)
        {
            bool[] isPrime = new bool[n + 1];
            int lastPrimeIndex = 0;
            for (int i = 2; i <= n; i++)
                isPrime[i] = true;
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    lastPrimeIndex = i;
                    for (int j = i * 2; j <= n; j += i)
                        isPrime[j] = false;
                }
            }
            return lastPrimeIndex;
        }

        public static int FindPrime2(int n)
        {
            for (int i = n; i >= 2; i--)
            {
                bool isPrime = true;
                for (int d = 2; d <= Math.Sqrt(i) + 1; d++)
                {
                    if (i % d == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                    return i;
            }

            return -1;
        }
    }

    class WorkerThread
    {
        public static List<string> Logs = new List<string>();
        public void WorkerStart(int n, string numeFir)
        {
            lock (Logs)
            {
                Logs.Add("Start fir: " + numeFir + " " + DateTime.Now.ToString("HH:mm:s:ffff") + " Numar natural dat: " + n.ToString());
            }
        }

        public void WorkerProgress(string numeFir)
        {
            lock (Logs)
            {
                Logs.Add("Iesire temporara fir: " + numeFir + " " + DateTime.Now.ToString("HH:mm:s:ffff"));
            }
        }

        public void WorkerExit1(int n, string numeFir)
        {
            lock (Logs)
            {
                Logs.Add("End fir: " + numeFir + " " + DateTime.Now.ToString("HH:mm:s:ffff") + " Numar prim = " + Prime.FindPrime(n));
            }
        }
        public void WorkerExit2(int n, string numeFir)
        {
            lock (Logs)
            {
                Logs.Add("End fir: " + numeFir+ " " + DateTime.Now.ToString("HH:mm:s:ffff") + " Numar prim = " + Prime.FindPrime2(n));
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numar: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var e1 = new WorkerThread();
            //var t1 = new Thread(()=> e1.WorkerStart(n));
            //t1.Name = "Thread 1";
            //t1.Start();

            string t1Name = null, t2Name = null;

            var t1 = new Thread(async delegate()
            {
                var workerThread = new WorkerThread();
                workerThread.WorkerStart(n, t1Name);
                workerThread.WorkerProgress(t1Name);
                workerThread.WorkerExit1(n, t1Name);
            });

            t1.Name = "Thread 1";
            t1Name = t1.Name;
            Console.WriteLine("Start fir:" + t1.Name);

            var t2 = new Thread(async delegate ()
            {
                var workerThread = new WorkerThread();
                workerThread.WorkerStart(n, t2Name);
                workerThread.WorkerProgress(t2Name);
                workerThread.WorkerExit2(n, t2Name);
                Thread.Sleep(500);
                foreach (var l in WorkerThread.Logs)
                    Console.WriteLine(l);
            });

            t2.Name = "Thread 2";
            t2Name = t2.Name;
            Console.WriteLine("Start fir:" + t2.Name);
            t1.Start();
            t2.Start();
        }
    }
}
