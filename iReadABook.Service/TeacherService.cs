using iReadABook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iReadABook.Service
{
    public class TeacherService
    {
        public void AddTeacher(string userName)
        {
            var context = new ApplicationDbContext();

            context.Teachers.Add(new Teacher { UserId = userName });
        }
    }
}
