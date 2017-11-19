using System.Collections.Generic;

namespace RxWorkOut.Core
{
    public interface IWorkOut
    {
        IEnumerable<int> DoWarmup { get; }

        void OnFinished();

        void OnProcessing(int i);     
    }

}