using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RxWorkOut.Core
{
    public class RegexObservableFile : IObservable<Match>
    {

        #region Private Members
        private readonly Regex _regex;
        private readonly string _filePath;
        
        #endregion


        public RegexObservableFile(Regex regex, string filePath)        
        {
            _regex=regex;
            _filePath=filePath;
        }

        public IDisposable Subscribe(IObserver<Match> observer)
        {
            throw new NotImplementedException();
        }


        private class State:IDisposable
        {
            internal bool Done=false;
            internal const int BufferOverlap=1000;
            internal const int BufferLimit=1000000;
            internal readonly char[] buffer;
            internal string Input;
            internal int CharacterCount;
            internal int LastMatchPosition;
            internal Match Match;
            internal readonly StreamReader streamReader;

            public State(StreamReader _streamReader)
            {
                buffer=new char[BufferLimit];                
                streamReader=_streamReader;
                CharacterCount=0;
                LastMatchPosition=0;
            }

            public void Dispose()
            {
                Done=true;
                streamReader.Dispose();
            }
            
        }
    }
}