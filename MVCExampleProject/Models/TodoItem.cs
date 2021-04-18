using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CompletedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
