using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.Domain.ValueObjects
{
    public class CourseInfo
    {
        public required string Title { get; set; }
        public string? Instructor { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }

        public CourseInfo() { }
        public CourseInfo(string title, string? instructor, string? duration, string? description)
        {
            Title = title;
            Instructor = instructor;
            Duration = duration;
            Description = description;
        }
    }
}
