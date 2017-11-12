using System;
using System.Linq;
using System.Threading;

namespace RxWorkOut
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
            Exercise4 obj=new Exercise4(); 
            obj.DoWorkOut();
        }
    }
}
