using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using System.Threading;

namespace RxWorkOut.Core
{
    public class Exercise9:WorkOut
    {
        public Exercise9():base()
        {
            
        }
        public override IEnumerable<int> DoWarmup
        {
            get
            {
                var numbers = from number in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }
                              select Slow(number);
                return numbers;

            }
        }

        public override void OnProcessing(int i)
        {
            using(new SimultaneousDelegatesCheck())
            {
                Console.WriteLine("Output Snoozing..");
                Thread.Sleep(1000);
                Console.WriteLine("Value: {0} \t Thread:{1}",i,Thread.CurrentThread.ManagedThreadId);
            }
        }

        static int Slow(int number)
        {
            Console.WriteLine("Slow Work");
            Thread.Sleep(1000);
            return number;
        }

        public void DoWorkOut()
        {
            //Use to track how many subscription delegates are running at once

            Console.WriteLine("Application\tThread: {0}",Thread.CurrentThread.ManagedThreadId);
            var seqDone=new ManualResetEvent(false);
            var queryObservable=this.DoWarmup.ToObservable(ThreadPoolScheduler.Instance).Finally(()=>seqDone.Set());   

            queryObservable.Subscribe(OnProcessing,this.OnError,OnFinished);

            seqDone.WaitOne();

            Console.WriteLine("Done");
        }
    }
}