using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Exception
{
    public abstract class TechLibraryException : SystemException
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();

    }
}
