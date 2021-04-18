using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Message { get; set; }
        public int TodoItemId { get; set; }
        public virtual TodoItem TodoItem { get; set; }
    }
}
