using System; 
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

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("Error :{0}",e.Message);
        }

        public virtual void OnProcessing(int i)
        {
            AllCore.ProcessNumber(i);
        }
    }

}