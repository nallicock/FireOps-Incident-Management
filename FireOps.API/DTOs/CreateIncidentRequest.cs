using System.ComponentModel.DataAnnotations;
using FireOps.Domain.Enums;

namespace FireOps.API.DTOs
{
    public class CreateIncidentRequest
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Description {  get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public IncidentPriority Priority { get; set; } = IncidentPriority.Medium;

        public IncidentStatus Status { get; set; } = IncidentStatus.New;
    }
}
