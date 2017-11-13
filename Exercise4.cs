using System.Reactive;
using System.Reactive.Linq;
using RxWorkOut.Core;
namespace RxWorkOut
{
    //Create Observer
    public class Exercise4:WorkOut
    {
        public Exercise4():base()
        {
            
        }

        public void DoWorkOut()
        {
            var observableuery=this.DoWarmup().ToObservable();  //Object which Implements IObservable Interaface
            //Create Observer
            var observer=Observer.Create<int>(this.OnProcessing); //Object which Implements IObserver Interface

            observableuery.Subscribe(observer);
        }
    }
}