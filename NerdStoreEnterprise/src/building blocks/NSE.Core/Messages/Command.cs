using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.Messages
{
    public abstract class Command
    {
        public DateTime TimeStamp { get; private set; }
    }
}
