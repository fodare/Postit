using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Postit.Models
{
    public class Post
    {
        [Required]
        public string Id { get; set; }
        public string? Title { get; set; }
        [Required]
        public string Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime PostedOn { get; set; }
    }
}