using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace RxWorkOut.Core
{
    public static  class AllCore{
        public static void ImDone()
        {
            Console.WriteLine("I am Done");
        }

        public static IEnumerable<int> DoWarmUp(bool printConsole=false)
        {
            var query=from number in Enumerable.Range(1,5) select number;
            
            if(printConsole)
                foreach(var number in query)
                {
                    Console.WriteLine("{0} Thread {1} ",number, Thread.CurrentThread.ManagedThreadId);
                }

            return query;
        }

        public static void ProcessNumber(int number)
        {
            Console.WriteLine("{0} Thread {1} ",number, Thread.CurrentThread.ManagedThreadId);
        }

    }   

}