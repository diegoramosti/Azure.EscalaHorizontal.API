using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.EscalaHorizontal.Core.Dto
{
    public sealed class ItemMessagem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
