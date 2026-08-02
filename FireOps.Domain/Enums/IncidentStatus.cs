using System;
using System.Collections.Generic;
using System.Text;

namespace FireOps.Domain.Enums
{
    public enum IncidentStatus
    {
        New = 1,
        Assigned = 2,
        EnRoute = 3,
        OnScene = 4,
        Resolved = 5,
        Closed = 6
    }
}
