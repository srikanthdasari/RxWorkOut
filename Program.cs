using System;
using System.Linq;
using System.Threading;
using RxWorkOut.Core;

namespace RxWorkOut
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
            Exercise9 obj=new Exercise9(); 
            obj.DoWorkOut();
        }
    }
}
