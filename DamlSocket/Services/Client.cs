using System;
using System.Threading.Tasks;
using DamlSocket.Exceptions;
using Newtonsoft.Json.Linq;

namespace DamlSocket.Services
{
    public class Client
    {
        public TaskCompletionSource<JObject> TcsInit { get; set; } = new TaskCompletionSource<JObject>();

        public TaskCompletionSource<JObject> Tcs { get; set; } = new TaskCompletionSource<JObject>();

        public TaskCompletionSource<string> TcsResponse { get; set; } = new TaskCompletionSource<string>();

        public bool CallInProgress { get; set; }


        public async Task<JObject> GetInputAsync(string response = null)
        {
            if (!string.IsNullOrWhiteSpace(response))
            {
                if (TcsResponse.Task.Status == TaskStatus.RanToCompletion)
                {
                    throw new HangupException();
                }

                TcsResponse.SetResult(response);
            }


            var param = Task.WaitAny(Tcs.Task, Task.Delay(TimeSpan.FromMinutes(10))) == 0 ? await Tcs.Task : null;
            if (param == null)
            {
                throw new ServerTimeoutException();
            }

            Tcs = new TaskCompletionSource<JObject>();
            return param;
        }

        public void ExecuteRedirect(string response)
        {
            if (response != null)
            {
                // lets prevent An attempt was made to transition a task to a final state when it had already completed.
                if (TcsResponse.Task.Status == TaskStatus.RanToCompletion)
                {
                    throw new HangupException();
                }

                TcsResponse.SetResult(response);


                CallInProgress = false;
                TcsResponse = new TaskCompletionSource<string>();
                TcsInit = new TaskCompletionSource<JObject>();
            }

            Tcs = new TaskCompletionSource<JObject>();
        }

        public async Task<string> GetResponseAsync()
        {
            var param = await TcsResponse.Task;
            TcsResponse = new TaskCompletionSource<string>();
            return param;
        }

        public void SetContext(JObject context)
        {
            TcsInit.SetResult(context);
        }

        public async Task<JObject> GetContextAsync()
        {
            return await TcsInit.Task;
        }
    }
}