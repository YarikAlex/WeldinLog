using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeldingLog.Models.Requests.Objects
{
    public class RenameObjectRequest
    {
        public int ObjectId { get; set; }
        public string NewObjectName { get; set; }
    }
}
