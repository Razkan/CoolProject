using System;
using System.Threading.Tasks;

namespace Library
{
    public static class TrackedLog
    {
        public static void Information(string message, Action action)
        {
            Serilog.Log.Information(Start(message));
            action.Invoke();
            Serilog.Log.Information(Done(message));
        }

        public static async void Information(string message, int maxAttempt, Action action)
        {
            Serilog.Log.Information(Start(message));
            for (var i = 0; i < maxAttempt; i++)
            {
                try
                {
                    Serilog.Log.Information($"Attempt {i + 1} of {3}");
                    action.Invoke();
                    Serilog.Log.Information(Done(message));
                    return;
                }

                catch (Exception e)
                {
                    Serilog.Log.Error(e, e.Message);
                }
                
                await Task.Delay(1000);
            }

            Serilog.Log.Information(Failed(message));
        }

        private static string Start(string message)
        {
            return "Run - " + message;
        }

        private static string Done(string message)
        {
            return "Done - " + message;
        }

        private static string Failed(string message)
        {
            return "Failed - " + message;
        }
    }
}