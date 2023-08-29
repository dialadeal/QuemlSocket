using System;
using System.Threading.Tasks;
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
            if (response != null)
                TcsResponse.SetResult(response);

            var param = Task.WaitAny(Tcs.Task, Task.Delay(TimeSpan.FromMinutes(10))) == 0 ? await Tcs.Task : null;
            if (param == null)
            {
                throw new TimeoutException();
            }

            Tcs = new TaskCompletionSource<JObject>();
            return param;
        }

        public void ExecuteRedirect(string response)
        {
            if (response != null)
            {
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