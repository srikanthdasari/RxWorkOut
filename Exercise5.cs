using System;
using System.Linq;
using System.Reactive.Linq;
using RxWorkOut.Core;

namespace RxWorkOut.Core
{
    public class Exercise5:WorkOut
    {
        public Exercise5():base()
        {
            
        }

        public void DoWorkOut()
        {
            var observableQuery=this.DoWarmup().ToObservable();

            var observer=new CoreObserver();

            observableQuery.Subscribe(observer);
        }

    }
}