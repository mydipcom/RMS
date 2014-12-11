using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rms.Web.Models.Common
{
    public class UIResponse
    {
        public UIResponse()
        {
            Msgs = new List<string>();
        }

        public UIResponse(bool result) : this()
        {
            Result = result;
        }

        public UIResponse(bool result, IList<string> msgs) : this(result)
        {
            Msgs = msgs;
        }

        public bool Result { get; set; }
        public IList<string> Msgs { get; set; }
    }
}