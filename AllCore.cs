using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RxWorkOut
{
    public static  class AllCore{
        public static void ImDone()
        {
            Console.WriteLine("I am Done");
        }

        public static IEnumerable<int> DoWarmUp()
        {
            var query=from number in Enumerable.Range(1,5) select number;

            foreach(var number in query)
            {
                Debug.WriteLine(number);
            }

            return query;
        }

    }   

}