using System.Reactive;
using System.Reactive.Linq;
using RxWorkOut.Core;
namespace RxWorkOut
{
    //Create Observer
    public class Exercise4
    {
        public Exercise4()
        {
            
        }

        public void DoWorkOut()
        {
            var observableuery=AllCore.DoWarmUp().ToObservable();  //Object which Implements IObservable Interaface
            //Create Observer
            var observer=Observer.Create<int>(AllCore.ProcessNumber); //Object which Implements IObserver Interface

            observableuery.Subscribe(observer);
        }
    }
}