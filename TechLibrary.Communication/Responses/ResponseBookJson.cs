using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Communication.Responses
{
    public class ResponseBookJson
    {
        public Guid id { get; set; }

        public string title { get; set; } = string.Empty;

        public string author { get; set; } = string.Empty;

    }
}
