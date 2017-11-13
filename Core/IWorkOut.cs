using System.Collections.Generic;

namespace RxWorkOut.Core
{
    public interface IWorkOut
    {
        IEnumerable<int> DoWarmup();

        void OnFinished();

        void OnProcessing(int i);     
    }

}