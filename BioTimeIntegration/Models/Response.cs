using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioTimeIntegration.Models
{
    public class Response<TData>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string msg { get; set; }
        public int Code { get; set; }

        public List<TData> Data { get; set; }

    }
}
