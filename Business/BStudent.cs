using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BStudent
    {
        public List<Student> Listar(string firstname, string lastname)
        {
            DStudent student = new DStudent();
            List<Student> students = new List<Student>();

            students = student.Listar(firstname, lastname);
            return students;
        }

        public void Grabar(string firstname, string lastname) { 
            DStudent dStudent = new DStudent();

            int idstudent = dStudent.Insert(firstname, lastname);
        }
    }
}
