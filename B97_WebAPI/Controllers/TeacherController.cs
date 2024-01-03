using B97_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B97_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public List<TeacherModel> GetAllTeachers()
        {
            return GetTeachers();
        }
        [HttpGet]
        public TeacherModel GetTeacherByID(int id)
        {
            return GetTeachers().FirstOrDefault(x => x.TeacherId == id);
        }


        private List<TeacherModel> GetTeachers()
        {
            List<TeacherModel> teacherModels = new List<TeacherModel>();
            teacherModels.Add(new TeacherModel
            {
                TeacherId = 2001,
                TeacherName = "Keerthi"
            });
            teacherModels.Add(new TeacherModel
            {
                TeacherId = 2002,
                TeacherName = "Shankar"
            });
            return teacherModels;
        }
    }
}
