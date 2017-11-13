using System.Collections.Generic;

namespace RxWorkOut.Core
{
    public class WorkOut : IWorkOut
    {
        public virtual IEnumerable<int> DoWarmup() { return AllCore.DoWarmUp();}

        public virtual void OnFinished()
        {
            AllCore.ImDone();
        }

        public virtual void OnProcessing(int i)
        {
            AllCore.ProcessNumber(i);
        }
    }

}