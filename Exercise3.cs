using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using RxWorkOut.Core;
namespace RxWorkOut
{
    public class Exercise3
    {
        public Exercise3()
        {
            
        }
        
        public void DoWorkOut()
        {
                var observableQuery=AllCore.DoWarmUp().ToObservable(scheduler: Scheduler.NewThread);
                observableQuery.Subscribe(AllCore.ProcessNumber,AllCore.ImDone);
        }
    }
}