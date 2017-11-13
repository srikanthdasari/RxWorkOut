using System;

namespace RxWorkOut.Core
{
    public class CoreObserver : IObserver<int>
    {
        
        public virtual void OnCompleted()
        {
            Console.WriteLine("I am done");
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("Error {0} ",error.Message);
        }

        public virtual void OnNext(int value)
        {
            Console.WriteLine(value);
        }
    }
}