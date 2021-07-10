using System.Threading;

namespace Server.Models
{
    public sealed class ResetEvent : EventWaitHandle
    {
        public ResetEvent() : base(false, EventResetMode.ManualReset) { }
    }
}
