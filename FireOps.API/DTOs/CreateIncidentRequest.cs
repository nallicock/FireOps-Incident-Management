using System.ComponentModel.DataAnnotations;

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
    }
}
