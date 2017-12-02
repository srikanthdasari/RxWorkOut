using System;
using System.IO;
using System.Reactive.Linq;

namespace RxWorkOut.Core
{
    public static class CoreExtensions
    {
        public static IObservable<byte[]> AsyncRead(this Stream stream, int bufferSize) 
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var asyncRead = Observable.FromAsyncPattern<byte[], int, int, int>(stream.BeginRead, stream.EndRead);

            var buffer = new byte[bufferSize];  

            return asyncRead(buffer, 0, bufferSize).Select(readBytes => 
            { 
                var newBuffer = new byte[readBytes]; 
                Array.Copy(buffer, newBuffer, readBytes);

                return newBuffer; 
            }); 
        }
    }
}