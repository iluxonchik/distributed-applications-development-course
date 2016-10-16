using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        delegate void ThrWork();

        /// <summary>
        /// You can have emoji in your docs 😂😂😂
        /// </summary>
        class ThrPool
        {

            private readonly int MAX_BUFF;
            private int currBuffSize = 0;
            private Queue<ThrWork> tasks;

            public ThrPool(int thrNum, int bufSize)
            {
                MAX_BUFF = bufSize;
                tasks = new Queue<ThrWork>(MAX_BUFF);
                for (int i = 0; i < thrNum; i++)
                {
                    new Thread(ThreadMethod).Start();
                }
            }

            public void AssyncInvoke(ThrWork action)
            {
                lock(tasks)
                {
                    while (currBuffSize == MAX_BUFF)
                    {
                        // aight, so the buffer is full, we can't put items in it, let's just wait
                        Monitor.Wait(tasks);
                    }
                    // aight, there is space in the buffer, so let's put the item in it
                    tasks.Enqueue(action);
                    currBuffSize += 1;
                    Monitor.Pulse(tasks);
                }
            }

            /// <summary>
            /// That's the method that each Thread instance runs.
            /// </summary>
            private void ThreadMethod()
            {
                while(true) { 
                    lock (tasks) { 
                        while (currBuffSize == 0)
                        {
                            // ain't a thang present in the buffer, so let's wait a lil bit
                            Monitor.Wait(tasks);
                        }
                        // aight, so we got something in the buffer now, let's get it!
                        ThrWork task = tasks.Dequeue();
                        currBuffSize -= 1;
                        task();
                    }

                }
            }
        }


        class A
        {
            private int _id;

            public A(int id)
            {
                _id = id;
            }

            public void DoWorkA()
            {
                Console.WriteLine("A-{0}", _id);
            }
        }


        class B
        {
            private int _id;

            public B(int id)
            {
                _id = id;
            }

            public void DoWorkB()
            {
                Console.WriteLine("B-{0}", _id);
            }
        }


        class Test
        {
            public static void Main()
            {
                ThrPool tpool = new ThrPool(5, 10);
                ThrWork work = null;
                for (int i = 0; i < 5; i++)
                {
                    A a = new A(i);
                    tpool.AssyncInvoke(new ThrWork(a.DoWorkA));
                    B b = new B(i);
                    tpool.AssyncInvoke(new ThrWork(b.DoWorkB));
                }
                Console.ReadLine();
            }
        }
    }
}