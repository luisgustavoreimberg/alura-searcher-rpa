using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.Application.DTOs
{
    public class SearchResponseDTO(string title, string? instructor, string duration, string description)
    {
        public required string Title { get; set; } = title;
        public string? Instructor { get; set; } = instructor;
        public string? Duration { get; set; } = duration;
        public string? Description { get; set; } = description;
    }
}
