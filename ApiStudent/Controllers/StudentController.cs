using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public List<Student> Listar()
        {
            BStudent bStudent = new BStudent();

            return bStudent.Listar("","");
        }

        [HttpPost]
        public void Insert(string firstname, string lastname) {
            BStudent bStudent = new BStudent();
            bStudent.Grabar(firstname, lastname);        
        }
    }

}
