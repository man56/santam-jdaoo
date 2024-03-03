using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace STM.DLayer
{
    public class QueryPerfCounter
    {
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);


        private double frequency;
        //Decimal multiplier = new Decimal(1.0e9);

        public QueryPerfCounter()
        {
            long frq;
            if (QueryPerformanceFrequency(out frq) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
            frequency = frq;
        }

        public double Read()
        {
            long start;
            QueryPerformanceCounter(out start);
            return start / frequency;
        }
    }

    public class Delay
    {
        private static Delay delay;
        private QueryPerfCounter queryPerfCounter;

        public static Delay Instance
        {
            get
            {
                if (delay == null) delay = new Delay();
                return delay;
            }
        }

        
        private Delay()
        {
            queryPerfCounter = new QueryPerfCounter();
        }

        public static void Sleep(double m10)
        {
            double end = m10 / 1000000.00;
            var instance = Delay.Instance;            
            double start = instance.queryPerfCounter.Read();
            end += start;
            while (start < end)
            {
                start = instance.queryPerfCounter.Read();
            }
        }
    }
}