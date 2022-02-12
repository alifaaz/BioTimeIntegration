using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioTimeIntegration.Models
{
    public class AbsentResponse:BaseResponseData
    {
        public string att_date { get; set; }
        public string check_in { get; set; }
        public string check_out { get; set; }
        public string Id { get;set; }

        public string total_hrs { get; set; }
        public string weekday { get; set; }

=    }
}
