using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingWebAPI.Models
{
    public class TicketPhase1
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ResolveDate { get; set; }
        public string ResolveBy { get; set; }

    }
}
