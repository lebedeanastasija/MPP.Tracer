﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TracerAPI;
using System.Diagnostics;

namespace TestTraceProgram
{
    class Program
    {
        static void Main(string[] args)
        {           
            Method1();            
            TraceResult result = Tracer.Instance.GetTraceResult();
            XMLFormatter f1 = new XMLFormatter("ThreadsTree.xml");
            ConsoleFormatter f2 = new ConsoleFormatter(); 
            f1.Format(result);
            f2.Format(result);
            Console.ReadLine();
        }

        public static void Method1()
        {
            Thread thread = new Thread(new ThreadStart(Method2));   
            thread.Start();

            Tracer.Instance.StartTrace();

            Thread.Sleep(200);
            Method2();
            Method3();
            thread.Join();
            Tracer.Instance.StopTrace();           
        }

        public static void Method2()
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Method4(4);
            Method7();
            Tracer.Instance.StopTrace();            
        }

        public static void Method3()
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Method5(4,3);
            Tracer.Instance.StopTrace();
        }

        public static void Method4(int a)
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);

            for (int i = 0; i < 7; i++)
            {
                Method6(4, 3);
            }

            Tracer.Instance.StopTrace();
        }

        public static void Method5(int a, int b)
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Tracer.Instance.StopTrace();
        }

        public static void Method6(int a, int b)
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Tracer.Instance.StopTrace();
        }

        public static void Method7()
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);

            for (int i = 0; i < 6; i++)
            {
                Thread thread = new Thread(Method8);
                thread.Start();
            }
            
            Tracer.Instance.StopTrace();
        }

        public static void Method8()
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Tracer.Instance.StopTrace();
        }
    }
}
