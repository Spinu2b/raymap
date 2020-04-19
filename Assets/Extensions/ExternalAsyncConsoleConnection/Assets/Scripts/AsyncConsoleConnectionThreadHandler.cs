using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Extensions.ExternalAsyncConsole.Assets.Scripts
{
    // Defines the data protocol for reading and writing strings on our stream.
    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len;
            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            var inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }

    public class AsyncConsoleConnectionThreadHandler
    {
        private Thread consoleConnectionThread;
        private string pipeName;

        private bool threadCanRun = false;

        private ConcurrentQueue<string> messagesToSend = new ConcurrentQueue<string>();

        public void StartConsoleHandling(string pipeName)
        {
            this.pipeName = pipeName;
            threadCanRun = true;
            consoleConnectionThread = new Thread(new ThreadStart(ConsoleWritingThread));
            consoleConnectionThread.Start();
        }

        public void EndConnection()
        {
            threadCanRun = false;
            consoleConnectionThread.Join();
        }

        private void ConsoleWritingThread()
        {
            var pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.Out);
            pipeClient.Connect();

            var streamString = new StreamString(pipeClient);
            while (threadCanRun)
            {
                if (messagesToSend.Count != 0)
                {
                    string message;
                    if (messagesToSend.TryDequeue(out message))
                    {
                        streamString.WriteString(message);
                    }
                }
            }
            pipeClient.Close();
        }

        public void LogDebug(string message)
        {
            messagesToSend.Enqueue(message);
        }
    }
}
