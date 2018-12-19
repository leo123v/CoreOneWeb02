using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOneWeb02.Models
{
    /// <summary>
    /// Blog entity
    /// </summary>
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string SubTitle { get; set; }

        [Required]
        public DateTime DateTimeAdd { get; set; }
    }
}
