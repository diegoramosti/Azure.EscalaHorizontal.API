using Azure.EscalaHorizontal.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.EscalaHorizontal.Batch
{
    class Program
    {
        #region properties
        const string baseAddress = "https://escalahorizontalapi.azurewebsites.net/api/";
        static readonly Dictionary<string, long> instancias = new Dictionary<string, long>();
        static RestClient _client; 
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Horizontal Scaling ...");            
            Timer t = new Timer(TimerCallback, null, 0, 300);

            _client = new RestClient(baseAddress);
            while (true)
            {
                Parallel.Invoke(
                        () => GetInformation(),
                        () => GetInformation(),
                        () => GetInformation(),
                        () => GetInformation());
            }
        }

        #region Methods
        static void GetInformation()
        {
            var request = new RestRequest("Server", Method.GET);

            _client.ExecuteAsync<ItemMessage>(request, response =>
            {
                if (response.Data != null)
                {
                    RequisicoesPorServer.Enqueue(response.Data);
                }
                else
                    Console.WriteLine($"Erro: {response.StatusCode} - {response.StatusDescription}");
            });

        }

        private static void TimerCallback(Object o)
        {
                RequisicoesPorServer.Dequeue();
                GC.Collect();
        } 
        #endregion

    }

}
