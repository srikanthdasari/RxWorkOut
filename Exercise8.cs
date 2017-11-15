using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using System.Reactive.Disposables;
using RxWorkOut.Core;
using System.IO;
using System.Linq;

namespace RxWorkOut
{
    public class Exercise8: WorkOut
    {
        public Exercise8():base()
        {

        }

        public void DoWorkOut()
        {
            var observableCharactersSeq=Observable.Using<char,StreamReader>(()=>new StreamReader(new FileStream("SomeNotes/ObserverPattern",FileMode.Open)),
                                        s=>(from c in s.ReadToEnd().ToCharArray() select c).ToObservable(NewThreadScheduler.Default));

            observableCharactersSeq.Subscribe(Console.Write);
        }

    }

    
}
