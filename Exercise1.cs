using System;
using System.Linq;
using RxWorkOut.Core;
namespace RxWorkOut
{

    public class Exercise1
    {
        public Exercise1()
        {
            
        }   

        public void DoWorkOut()
        {
            AllCore.DoWarmUp();
            AllCore.ImDone();
        }
        
    }

}