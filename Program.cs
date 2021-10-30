using System;
using System.Diagnostics;

namespace monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            string procesName = args[0];
            int duration = Convert.ToInt32(args[1]);
            int clock = Convert.ToInt32(args[2]) * 60 * 1000; // to milliseconds

            bool flag = true;
            while(flag)
            {
                Process[] processes = Process.GetProcessesByName(procesName);
                if (processes.Length != 0)
                {
                    foreach(Process i in processes)
                    {
                        if ((DateTime.Now - i.StartTime).TotalMinutes > duration)
                        {
                            i.Kill();
                        }
                    }
                    System.Threading.Thread.Sleep(clock);

                }
                else
                {
                    flag = false;

                }
            }


        }
    }
}
