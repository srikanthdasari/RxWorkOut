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
            Exercise8 obj=new Exercise8(); 
            obj.DoWorkOut();
        }
    }
}
