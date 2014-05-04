using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iReadABook.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
