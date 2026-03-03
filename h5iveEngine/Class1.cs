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
 
namespace h5iveEngine
{
    public class EngineCore
    {
        private static readonly EngineCore instance = new EngineCore();
        public static EngineCore h5iveEngine => instance;

        static EngineCore() { }
        private EngineCore()
        {

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
    
        



    

