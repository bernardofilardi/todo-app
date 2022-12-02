using System.ComponentModel.DataAnnotations;

namespace ToDo.Application.Dtos.Item
{
    public class CreateItemRequestDto
    {
        [Required]
        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }
    }
}
