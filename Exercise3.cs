using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.PlatformServices;
using RxWorkOut.Core;
using System.Threading;

namespace RxWorkOut
{
    public class Exercise3:WorkOut
    {
        public Exercise3():base()
        {
            
        }
        
        public override void OnProcessing(int i)
        {
            Console.WriteLine("Snooz...");
            Thread.Sleep(1000);
            Console.WriteLine(" Value : {0} \t Thread : {1} ", i,Thread.CurrentThread.ManagedThreadId);
        }

        public void DoWorkOut()
        {
                var observableQuery=this.DoWarmup.ToObservable(scheduler: NewThreadScheduler.Default);
                observableQuery.Subscribe(this.OnProcessing,this.OnFinished);
        }
    }
}