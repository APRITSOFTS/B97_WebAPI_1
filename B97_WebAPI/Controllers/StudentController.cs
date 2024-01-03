using B97_WebAPI.Models;
using B97_WebAPI.Models.Filters;
using B97_WebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B97_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ServiceFilter(typeof(B97ActionFilter))]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public List<StudentModel> GetAllStudents()
        {
            return _studentRepository.GetStudents();
        }
        [HttpGet]
        public ActionResult<StudentModel> GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }
        [HttpPost]
        public ActionResult<int> CreateStudent(StudentModel studentModel)
        {
            return _studentRepository.CreateStudent(studentModel);
        }

        [HttpPut]
        public ActionResult<bool> UpdateStudent(StudentModel studentModel)
        {
            return _studentRepository.UpdateStudent(studentModel);
        }
        [HttpDelete]
        public ActionResult<bool> DeleteStudent(int id)
        {
           return _studentRepository.DeleteStudent(id);
        }
    }
}
