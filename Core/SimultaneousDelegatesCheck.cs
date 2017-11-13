using System;
using System.Threading;

namespace RxWorkOut.Core
{
    public class SimultaneousDelegatesCheck : IDisposable
    {
        private static int _simultaneousDelegateCount=0;
        public void Dispose()
        {
            Interlocked.Decrement(ref _simultaneousDelegateCount);
        }


        public SimultaneousDelegatesCheck()
        {
            var usage=0;

            if((usage=Interlocked.Increment(ref _simultaneousDelegateCount))!=1)
            {
                //if another delegate has started but not completed its work
                //this _simultaneousDelegateCount will not be 1 at this point
                Console.WriteLine("{0} delegates are running concurently",usage);
            }
        }
    }

}