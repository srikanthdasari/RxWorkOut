using System;
using System.Linq;
using System.Reactive.Linq;
using RxWorkOut.Core;
namespace RxWorkOut
{
    public class Exercise2:WorkOut
    {
        public Exercise2():base()
        {
            
        }   

        public void DoWorkOut()
        {
            var observablequery=this.DoWarmup().ToObservable();
            observablequery.Subscribe(Console.Write, this.OnFinished);
        }
    }
}