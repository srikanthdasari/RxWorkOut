using System;
using System.Linq;
using System.Reactive.Linq;

namespace RxWorkOut
{
    public class Exercise2
    {
        public Exercise2()
        {
            
        }   

        public void DoWorkOut()
        {
            var observablequery=AllCore.DoWarmUp().ToObservable();
            observablequery.Subscribe(Console.Write, AllCore.ImDone);
        }
    }
}