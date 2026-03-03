// based on the Unity Engine Excution Order: https://docs.unity3d.com/6000.3/Documentation/Manual/execution-order.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using static h5iveEngine.EngineUtils;
using static h5iveEngine.EngineStatistics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace h5iveEngine
{
    public class EngineCore
    {
        #region Core Singleton
        private static readonly EngineCore instance = new EngineCore();
        public static EngineCore h5iveEngine => instance;

        static EngineCore() { }
        private EngineCore()
        {
            InitializeEngine();
        }
        public static bool EngineCoreInit() => h5iveEngine != null;
        #endregion

        private static void InitializeEngine()
        {

            Console.CursorVisible = false;
            Debug.log("Initializing Core Engine Modules...");
            if (!InitEngineModules())
            {
                throw new Exception("Failed to initialize Engine Core, check log output for details.");
            }
            Debug.Log("Engine Initialzied Successfully, press any key to continue...");
            WaitForInput();

            FrameStateModule.RunEngineCycle();

        }

        private static bool InitEngineModules()
        {
            if (!BehaviourControlModule.InitializeBehaviourControlModule())
            {
                throw new Exception("Failed to initialize Behaviour Control Module.");
            }
            Debug.Log("Initializing Engine Frame Cycle...");
            if (!FrameStateModule.InitializeEngineFrameCycle())
            {
                throw new Exception("Failed to initialize Engine Frame Cycle.");
            }
            return true;
        }
    }
    public static class EngineStatistics
    {
        private static int frameCount = 0;
        public static int totalFrames { get => frameCount; }
        public static void IncrementFrameCount() => frameCount++;
        public static int currentFrame => totalFrames + 1;
        public static bool lockFrameRate = true;
        public static float targetFrameRate = 60;
        public static bool disableConsoleOutput = false;
    }

    public static class EngineUtils
    {
#nullable enable
        public static void print(object? message = null, char end = char.MinValue)
        {
            if (disableConsoleOutput)
                return;
            if (message == null)
            {
                message = "\n";
            }

            Console.Write((message ?? "").ToString() + end);
        }

        public static void WaitForInput()
        {
            Console.ReadKey();
        }
#nullable disable

        public static void ConsoleCurrentLineClear()
        {
            int line = Console.CursorTop;

            int width = Math.Max(1, Console.WindowWidth);

            Console.SetCursorPosition(0, line);

            Console.Write(new string(' ', width));

            Console.SetCursorPosition(0, line);
        }
        public static void ConsoleWriteLoadingDots(int count, int dotcount)
        {

            ConsoleCurrentLineClear();
            Console.Write(String.Concat(Enumerable.Repeat(".", count % dotcount + 1)));
        }


        public struct ColoredText
        {

            public string Text { get; }
            public ConsoleColor Color { get; }
            public ColoredText(string text, ConsoleColor color)
            {
                Text = text ?? String.Empty;
                Color = color;
            }

            public void Write(char end = char.MinValue)
            {
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = Color;
                print(Text + end);
                Console.ForegroundColor = prev;
            }
            public override string ToString() => Text;
        }
    }

#if DEBUG
    public static class Debug
    {
        public static bool ENABLE_DEBUG_LOGS = true;

        public enum LogType
        {
            LOG,
            WARNING,
            ERROR,
            MESSAGE,
            NONE
        }

        internal static void DebugOut(LogType type, string message, bool TimeStamp = true, char end = '\n')
        {
            if (!ENABLE_DEBUG_LOGS || disableConsoleOutput)
                return;

            var prev = Console.ForegroundColor;

            print($"{(TimeStamp ? DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss ") : "")}[");
            switch (type)
            {
                case LogType.LOG:
                    new ColoredText("LOG", ConsoleColor.Green).Write();
                    break;
                case LogType.WARNING:
                    new ColoredText("WRN", ConsoleColor.Yellow).Write();
                    break;
                case LogType.ERROR:
                    new ColoredText("ERR, ConsoleColor.Red).Write();
                    break;
                case LogType.MESSAGE:
                default:
                    print("MSG");
                    break;
            }


    Console.WriteLine("Engine Initialized.");
            while (true)
            {
                Console.WriteLine("...");
            }
        }
        public static bool Init() { return h5iveEngine != null; }
    }


    public static class Utils
    {

        public static void Print(object message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}
    
        



    

