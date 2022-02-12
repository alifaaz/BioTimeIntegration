using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioTimeIntegration.Models
{
    public class Parameters:BaseParameters
    {

        public int? departments { get; set; }
        public int? area { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }  
    }
}
