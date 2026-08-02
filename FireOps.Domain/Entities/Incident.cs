using System;
using System.Collections.Generic;
using System.Text;
using FireOps.Domain.Enums;

namespace FireOps.Domain.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string IncidentNumber { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public IncidentPriority Priority { get; set; }
        public IncidentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}
