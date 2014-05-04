using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iReadABook.Data
{
    public class Question
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Book  Books { get; set; }
    }
}
