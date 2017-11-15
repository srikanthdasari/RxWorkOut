using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using System.Reactive.Disposables;
using RxWorkOut.Core;
namespace RxWorkOut
{
    public class Exercise7: WorkOut
    {
        public Exercise7():base()
        {

        }

        public void DoWorkOut()
        {
            //Observvable seuence ruon on the new thread
            var observableQuery=this.DoWarmup().ToObservable(NewThreadScheduler.Default);
            // Observable seuence that adds disposable object to the
            // objects that rx will clean up when it is finidh processing sequence
            var observableWithDispose=Observable.Using<int,CoreDispose>(()=>new CoreDispose(),d=>observableQuery);
            //Check Console Output and you will see that Coredispose.Dispose is called after the seuence has been processed
            observableWithDispose.Subscribe(Console.WriteLine);
        }

    }

    
}
