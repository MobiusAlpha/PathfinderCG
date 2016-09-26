using System;
using System.Collections.Concurrent;
using System.Threading;

namespace CharacterGen.ConsoleApp
{
    public class CommandModule : ICommandModule
    {
        private readonly ManualResetEvent _runHandle;
        private readonly Thread intakeThread;

        public CommandModule(ManualResetEvent runHandle)
        {
            _runHandle = runHandle;
            intakeThread = new Thread(intake) { IsBackground = true };
            intakeThread.Start();
        }

        ~CommandModule()
        {
            intakeThread.Join();
        }
        
        public BlockingCollection<string> InputStream { get; } = new BlockingCollection<string>();
        public BlockingCollection<string> OutputStream { get; } = new BlockingCollection<string>();

        private string _execute(string command)
        {
            throw new NotImplementedException();
        }

        private void intake()
        {
            while (!_runHandle.WaitOne(0))
            {
                string command = InputStream.Take();

                new Thread(process) { IsBackground = true }.Start(command);
            }
        }

        private void process(object command)
        {
            string response = _execute((string)command);

            OutputStream.Add(response);
        }
    }
}