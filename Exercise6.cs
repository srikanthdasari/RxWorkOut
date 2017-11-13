using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace RxWorkOut.Core
{
    public class Exercise6:WorkOut
    {
        public Exercise6():base()
        {
            
        }
        public override IEnumerable<int> DoWarmup()
        {
            
            var numbers = from number in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12 }
                              select Slow(number);
                
            return numbers;
            
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
            var queryObservable=this.DoWarmup().ToObservable();   

            queryObservable.Subscribe(OnProcessing,OnFinished);

            Observable.Start(()=>{
                Thread.Sleep(3500);
                using(new SimultaneousDelegatesCheck())
                {
                    Console.WriteLine("Nemisis is passing");
                    Thread.Sleep(2000);
                }
                Console.WriteLine("Nemisis has passed");
            });
        }
    }
}