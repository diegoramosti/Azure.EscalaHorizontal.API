using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.EscalaHorizontal.Common
{
    public static class RequisicoesPorServer
    {
        public static Queue<string> _serversQueue = new Queue<string>();
        private static List<Server> _totalPorServer = new List<Server>();
        public static void Enqueue(ItemMessage message)
        {
            try
            {
                _serversQueue.Enqueue(message.Message);
            }
            catch (Exception)
            {
            }
        }

        public static void Dequeue()
        {
            while (_serversQueue.Count > 0)
            {
                try
                {
                    var item = _serversQueue.Dequeue();

                    if (!string.IsNullOrEmpty(item))
                    {
                        if (_totalPorServer.Any(c => c.name == item))
                        {
                            _totalPorServer.FirstOrDefault(c => c.name == item).count++;
                        }
                        else
                        {
                            _totalPorServer.Add(new Server { name = item, count = 1 });
                        }

                        var mensagem = new StringBuilder();

                        foreach (var s in _totalPorServer)
                        {
                            mensagem.Append($"Server:({s.name}) - :{s.count} | ");
                        }
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine("\r {0}   ", mensagem.ToString());
                    }
                }
                catch (Exception)
                {
                }
            }
        }

    }

    public class Server
    {
        public string name { get; set; }
        public int count { get; set; }

    }
}
