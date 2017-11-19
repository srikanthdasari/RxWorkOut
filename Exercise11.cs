using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.PlatformServices;
using System.Reactive.Threading;
using RxWorkOut;
using RxWorkOut.Core;
using System.Text.RegularExpressions;

namespace RxWorkOut
{
    public class Exercise11:WorkOut
    {

        const string input="xyz abc ysr abcd lgb12 abc trvs abc9 r  r92 trsc";
        public Exercise11():base()
        {
            
        }

        public void DoWorkOut()
        {   
            var regex=new Regex(@"abc[^][^\s]*");
            var match=regex.Match(input);

            #if false
                while (match.Success)
                {
                    Console.WriteLine(match.Value);
                    match=match.NextMatch();
                }
            #endif

            var sequence=RegexMatchToEnum(regex,input).ToObservable();
            sequence.Subscribe(m=>Console.WriteLine(m.Value));
            
        }

        private IEnumerable<Match> RegexMatchToEnum(Regex regex,string input)
        {
            var match=regex.Match(input);
            while(match.Success)
            {
                yield return match;
                match=match.NextMatch();
            }
        }
    }
}