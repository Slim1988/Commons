namespace ATR.Common.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Class used to measure performance. A wrapper to StopWatch .net class
    /// The class is maintaining a pool of counters that are reused for all timing measure.
    /// The set of counters is stored in counters Dictionary. A stack of free counters is maintained in parallel to
    /// identify the counters that are available for use.
    /// At the application start, both list (dictionary and stack) are empty.
    /// The link between counters in the stack and the Dictionary is performed the Dictionary key.
    /// In order to get the key from the object itself, the value is set to the object hash code
    /// </summary>
    public static class Timer
    {
        #region Static Fields

        /// <summary>
        /// List of all counters
        /// </summary>
        private static readonly Dictionary<int, Stopwatch> Counters = new Dictionary<int, Stopwatch>();

        /// <summary>
        /// Stack of free counters
        /// </summary>
        private static readonly Stack<Stopwatch> FreeCounters = new Stack<Stopwatch>();

        /// <summary>
        /// Time since last cleaning
        /// </summary>
        private static DateTime lastCleanTime;

        #endregion Static Fields

        #region Public static methods

        /// <summary>
        /// Returns a new instance of timer. The timer is running when returned.
        /// </summary>
        /// <param name="currentLogger">The logger to use in start process.</param>
        /// <returns>Identifier of timer created and started.</returns>
        public static int Start(ILogManager currentLogger)
        {
            // Free the counters that are running for more than 1 hour. That means that StartTimeMeasure was called but not StopTimeMeasure
            if (lastCleanTime.AddHours(1).CompareTo(DateTime.Now) > 0)
            {
                int orphanedCounters = 0;

                lock (FreeCounters)
                {
                    foreach (Stopwatch item in Counters.Values)
                    {
                        if (item.ElapsedMilliseconds <= 3600 * 1000)
                        {
                            continue;
                        }

                        item.Reset();
                        FreeCounters.Push(item);
                        orphanedCounters++;
                    }
                }

                if (orphanedCounters > 0 && currentLogger != null)
                {
                    currentLogger.Warn("{0} Orphaned counters found during cleaning. Please check unstopped timers.", args: new object[] { orphanedCounters });
                }

                lastCleanTime = DateTime.Now;
            }

            lock (FreeCounters)
            {
                Stopwatch watch;

                if (FreeCounters.Count > 0)
                {
                    watch = FreeCounters.Pop();
                }
                else
                {
                    watch = new Stopwatch();
                    Counters.Add(watch.GetHashCode(), watch);
                }

                watch.Restart();

                return watch.GetHashCode();
            }
        }

        /// <summary>
        /// Stops the timer and returns the elapsed time in millisecond since acquired.
        /// Then the timer is returned in the free counters stack.
        /// </summary>
        /// <param name="id">Counter identifier.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public static long Stop(int id)
        {
            lock (FreeCounters)
            {
                Stopwatch watch;
                long time = -1;

                bool found = Counters.TryGetValue(id, out watch);
                if (!found)
                {
                    return time;
                }

                watch.Stop();
                time = watch.ElapsedMilliseconds;
                watch.Reset();
                FreeCounters.Push(watch);

                return time;
            }
        }

        /// <summary>
        /// Restart the timer and returns the elapsed time in millisecond since acquired.
        /// </summary>
        /// <param name="id">Timer identifier.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public static long Restart(int id)
        {
            Stopwatch watch;
            long time = -1;

            bool found = Counters.TryGetValue(id, out watch);
            if (!found)
            {
                return time;
            }

            time = watch.ElapsedMilliseconds;
            watch.Restart();

            return time;
        }

        #endregion Public static methods
    }
}
