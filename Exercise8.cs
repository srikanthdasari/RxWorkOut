using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using System.Reactive.Disposables;
using RxWorkOut.Core;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace RxWorkOut
{
    public class Exercise8: WorkOut
    {
        public long Method1Time {get;set;}
        public Exercise8():base()
        {

        }

        public void DoWorkOut()
        {
            Method1();
        }


        public void Method1()
        {
            var watch=System.Diagnostics.Stopwatch.StartNew();
            var observableCharactersSeq=Observable.Using<char,StreamReader>(()=>new StreamReader(new FileStream("SomeNotes/tag.txt",FileMode.Open)),
                                        s=>(from c in s.ReadToEnd().ToCharArray() select c).ToObservable(NewThreadScheduler.Default));

            observableCharactersSeq.Subscribe(Console.WriteLine);
            watch.Stop();
            Console.WriteLine(" IT took Time :"+watch.ElapsedMilliseconds);
        }


        /*public void Method2()
        {
            var watch=System.Diagnostics.Stopwatch.StartNew();
            var observableCharactersSeq=Observable.Using<byte,StreamReader>(()=>new StreamReader(new FileStream("SomeNotes/tag.txt",FileMode.Open).AsyncRead(1024).RunAsync(z=>z.)))

            observableCharactersSeq.Subscribe(Console.WriteLine);
            watch.Stop();
            Method1Time=watch.ElapsedMilliseconds;
        }*/

        



    }

    
}
