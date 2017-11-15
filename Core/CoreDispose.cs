using System;

namespace RxWorkOut.Core
{
    public class CoreDispose : IDisposable
    {
        public void Dispose() => Console.WriteLine("I Have been disposed");
    }
}