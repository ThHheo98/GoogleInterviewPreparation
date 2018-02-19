using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    internal static class AsyncCoordinatorDemo
    {
        public static void Go()
        {
            const Int32 timeout = 50000; // Change to desired timeout
            var act = new MultiWebRequests(timeout);
            Console.WriteLine("All operations initiated (Timeout={0}). Hit <Enter> to cancel.",
                (timeout == Timeout.Infinite) ? "Infinite" : (timeout + "ms"));
            Console.ReadLine();
            act.Cancel();

            Console.WriteLine();
            Console.WriteLine("Hit enter to terminate.");
            Console.ReadLine();
        }

        private sealed class AsyncCoordinator
        {
            private Action<CoordinationStatus> m_callback;
            private Int32 m_opCount = 1; // Decremented when AllBegun calls JustEnded
            private Int32 m_statusReported; // 0=false, 1=true
            private Timer m_timer;

            // This method MUST be called BEFORE initiating an operation
            public void AboutToBegin(Int32 opsToAdd = 1)
            {
                Interlocked.Add(ref m_opCount, opsToAdd);
            }

            // This method MUST be called AFTER an operations result has been processed
            public void JustEnded()
            {
                if (Interlocked.Decrement(ref m_opCount) == 0)
                    ReportStatus(CoordinationStatus.AllDone);
            }

            // This method MUST be called AFTER initiating ALL operations
            public void AllBegun(Action<CoordinationStatus> callback, Int32 timeout = Timeout.Infinite)
            {
                m_callback = callback;
                if (timeout != Timeout.Infinite)
                {
                    m_timer = new Timer(TimeExpired, null, timeout, Timeout.Infinite);
                }
                JustEnded();
            }

            private void TimeExpired(Object o)
            {
                ReportStatus(CoordinationStatus.Timeout);
            }

            public void Cancel()
            {
                if (m_callback == null)
                    throw new InvalidOperationException("Cancel cannot be called before AllBegun");
                ReportStatus(CoordinationStatus.Cancel);
            }

            private void ReportStatus(CoordinationStatus status)
            {
                if (m_timer != null)
                {
                    // If timer is still in play, kill it
                    Timer timer = Interlocked.Exchange(ref m_timer, null);
                    if (timer != null) timer.Dispose();
                }

                // If status has never been reported, report it; else ignore it
                if (Interlocked.Exchange(ref m_statusReported, 1) == 0)
                    m_callback(status);
            }
        }

        private enum CoordinationStatus
        {
            AllDone,
            Timeout,
            Cancel
        };

        private sealed class MultiWebRequests
        {
            // This helper class coordinates all the asynchronous operations
            private readonly AsyncCoordinator _ac = new AsyncCoordinator();

            // Set of Web servers we want to query & their responses (Exception or Int32)
            private readonly Dictionary<String, Object> _servers = new Dictionary<String, Object>
            {
                {"http://Wintellect.com/", null},
                {"http://Microsoft.com/", null},
                {"http://1.1.1.1/", null}
            };

            public MultiWebRequests(Int32 timeout = Timeout.Infinite)
            {
                // Asynchronously initiate all the requests all at once
                var httpClient = new HttpClient();
                foreach (string server in _servers.Keys)
                {
                    _ac.AboutToBegin();
                    httpClient.GetByteArrayAsync(server).ContinueWith(task => ComputeResult(server, task));
                }

                // Tell AsyncCoordinator that all operations have been initiated and to call
                // AllDone when all operations complete, Cancel is called, or the timeout occurs
                _ac.AllBegun(AllDone, timeout);
            }

            private void ComputeResult(String server, Task<Byte[]> task)
            {
                Object result;
                if (task.Exception != null)
                {
                    result = task.Exception.InnerException;
                }
                else
                {
                    // Process I/O completion here on thread pool thread(s)
                    // Put your own compute-intensive algorithm here...
                    result = task.Result.Length; // This example just returns the length
                }

                // Save result (exception/sum) and indicate that 1 operation completed
                _servers[server] = result;
                _ac.JustEnded();
            }

            // Calling this method indicates that the results don't matter anymore
            public void Cancel()
            {
                _ac.Cancel();
            }

            // This method is called after all Web servers respond, 
            // Cancel is called, or the timeout occurs
            private void AllDone(CoordinationStatus status)
            {
                switch (status)
                {
                    case CoordinationStatus.Cancel:
                        Console.WriteLine("Operation canceled.");
                        break;

                    case CoordinationStatus.Timeout:
                        Console.WriteLine("Operation timed-out.");
                        break;

                    case CoordinationStatus.AllDone:
                        Console.WriteLine("Operation completed; results below:");
                        foreach (var server in _servers)
                        {
                            Console.Write("{0} ", server.Key);
                            Object result = server.Value;
                            if (result is Exception)
                            {
                                Console.WriteLine("failed due to {0}.", result.GetType().Name);
                            }
                            else
                            {
                                Console.WriteLine("returned {0:N0} bytes.", result);
                            }
                        }
                        break;
                }
            }
        }
    }
}