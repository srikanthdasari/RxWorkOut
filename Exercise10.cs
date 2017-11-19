using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace RxWorkOut.Core
{
    public class Exercise10:WorkOut
    {
        public Exercise10():base()
        {
            
        }

        public void DoWorkOut()
        {
            var observableQuery=this.DoWarmup.ToObservable();
            //Accumulator initialized to first value on first pass
            //instead of using delegate to caliculate its value
            //first value output is always the same as first value in sequence
            //change operation to '*' and you will see that accumulator
            //is *not* initialized to zero
             
            //var runningSum=observableQuery.Scan((accumulator,value)=>accumulator*value);
            var runningSum=observableQuery.Scan(10,(accumulator,value)=>accumulator+value);
            runningSum.Subscribe(Console.WriteLine);
        } 
    }
}