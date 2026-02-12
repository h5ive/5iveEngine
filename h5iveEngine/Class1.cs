// based on the Unity Engine Excution Order: https://docs.unity3d.com/6000.3/Documentation/Manual/execution-order.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
    
        



    

