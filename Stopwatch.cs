using System;

namespace StopwatchApp
{
    public class Stopwatch
    {
        public delegate void StopwatchEventHandler(string message);
        public event StopwatchEventHandler OnStarted;
        public event StopwatchEventHandler OnStopped;
        public event StopwatchEventHandler OnReset;

        private TimeSpan timeElapsed;
        private bool isRunning;

        public Stopwatch()
        {
            timeElapsed = TimeSpan.Zero;
            isRunning = false;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                OnStarted?.Invoke("Stopwatch Started!");
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                OnStopped?.Invoke("Stopwatch Stopped!");
            }
        }

        public void Reset()
        {
            timeElapsed = TimeSpan.Zero;
            isRunning = false;
            OnReset?.Invoke("Stopwatch Reset!");
        }

        public void Tick()
        {
            if (isRunning)
            {
                timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
            }
        }

        public TimeSpan GetElapsedTime()
        {
            return timeElapsed;
        }
    }
}
