using System.Diagnostics;

namespace RunOnTray
{
    public class CpuUsageTimer
    {
        private const float WEIGHT = 10f;

        private PerformanceCounter cpuUsageCounter = new PerformanceCounter("Processor Information", "% Processor Utility", "0,_Total");
        private Thread timerThread = null;
        private float DEFAULT_INTERVAL = 500f;
        
        public event EventHandler? Tick;

        public CpuUsageTimer()
        {
            timerThread = new Thread(Run);
            timerThread.Name = "CPUUSageTimer";
            timerThread.IsBackground = true;
        }

        private void Run()
        {
            float interval;
            float cpuUsage = cpuUsageCounter.NextValue();
            while (true)
            {
                if (Tick == null)
                {
                    Thread.Yield();
                }

                cpuUsage = (cpuUsageCounter.NextValue());

                if (cpuUsage < 10)
                {
                    interval = DEFAULT_INTERVAL;
                }
                else
                {
                    interval = DEFAULT_INTERVAL / (cpuUsage / WEIGHT);
                }
                
                Tick?.Invoke(null, null);

                Thread.Sleep((int)(interval));
            }
        }

        public void Start()
        {
            timerThread.Start();
        }


        public void SetInterval(bool speedUp)
        {
            if (speedUp)
            {
                DEFAULT_INTERVAL = Math.Max(200, DEFAULT_INTERVAL - 100);
            }
            else
            {
                DEFAULT_INTERVAL = Math.Min(1000, DEFAULT_INTERVAL + 100);
            }
        }

        public Thread GetTimerThread()
        {
            return timerThread;
        }
    }
}
