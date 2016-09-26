using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CharacterGen.Common;
using SimpleInjector;

namespace CharacterGen.ConsoleApp
{
    class Program
    {
        private static ICommandModule _commandModule;
        private static readonly ManualResetEvent _runHandle = new ManualResetEvent(false);
        private static object _consoleLock = new object();

        static void Main(string[] args)
        {
            Console.Title = "Pathfinder Character Generator v" + Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine("Getting ready, please wait...");

            RuntimeContext context = new RuntimeContext();

            Container container = new Container();

            Console.WriteLine("Making a map...");
            Bootstrap(container);

            Console.WriteLine("Perparing daily spells...");
            IConfigurationProvider configurationProvider = new FileConfigurationProvider();

            IEnumerable<IConfigurable> configurables = container.GetCurrentRegistrations().Where(p => p.ServiceType.IsInstanceOfType(typeof(IConfigurable))).Select(p => p.GetInstance()).Cast<IConfigurable>();

            foreach (IConfigurable configurable in configurables)
            {
                configurable.Configure(configurationProvider);
            }

            Console.WriteLine("Waking up demons...");
            IEnumerable<IStartable> startables = container.GetCurrentRegistrations().Where(p => p.ServiceType.IsInstanceOfType(typeof(IStartable))).Select(p => p.GetInstance()).Cast<IStartable>();

            foreach (IStartable startable in startables)
            {
                startable.Start(context);
            }

            _commandModule = new CommandModule(_runHandle);

            Console.WriteLine("Ready? (Press Any Key)");
            Console.ReadKey();

            Console.Clear();

            Thread inputThread = new Thread(Input);
            Thread outputThread = new Thread(Output);

            outputThread.Start();
            inputThread.Start();

            _runHandle.WaitOne();

            Console.WriteLine("Breaking down camp...");
            IEnumerable<IStoppable> stoppables = container.GetCurrentRegistrations().Where(p => p.ServiceType.IsInstanceOfType(typeof(IStoppable))).Select(p => p.GetInstance()).Cast<IStoppable>();

            foreach (IStoppable stoppable in stoppables)
            {
                stoppable.Stop(context);
            }

            inputThread.Join();
            outputThread.Join();

            Console.WriteLine("Done. Exiting!");
        }

        static void Bootstrap(Container container)
        {
            //TODO: Fill in service registrations
        }

        static void Input()
        {
            StringBuilder builder = new StringBuilder();

            while (!_runHandle.WaitOne(0))
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (_shortcutKeys.ContainsKey(key.Key))
                {
                    lock (_consoleLock)
                    {
                        Console.WriteLine(_shortcutKeys[key.Key]);
                    }

                    _commandModule.InputStream.Add(_shortcutKeys[key.Key]);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    lock (_consoleLock)
                    {
                        Console.WriteLine(builder.ToString());
                    }

                    _commandModule.InputStream.Add(builder.ToString());

                    builder.Clear();
                }
                else
                {
                    builder.Append(key.KeyChar);
                }
            }
        }

        static void Output()
        {
            while (!_runHandle.WaitOne(0))
            {
                string streamItem;
                while (_commandModule.OutputStream.TryTake(out streamItem))
                {
                    lock (_consoleLock)
                    {
                        Console.WriteLine(streamItem);
                    }
                }
            }
        }

        static readonly Dictionary<ConsoleKey, string> _shortcutKeys = new Dictionary<ConsoleKey, string>()
        {
            { ConsoleKey.Escape, "exit" },
            { ConsoleKey.F1, "help" },
            { ConsoleKey.F2, "save" },
            { ConsoleKey.LeftArrow, "back" },
            { ConsoleKey.RightArrow, "next" }
        };
    }
}
