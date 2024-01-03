using B97_WebAPI.DBModels;

namespace B97_WebAPI.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public List<StudentModel> GetStudents()
        {
            List<StudentModel> studentList = new List<StudentModel>();

            using (var _context = new B97Context())
            {
                foreach (var student in _context.Students.ToList())
                {
                    var studentModel = new StudentModel()
                    {
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        StudentDateofBirth= student.StudentDateofBirth,
                        BranchName = _context.Branches.Where(x => x.BranchId == student.BranchId).Select(y => y.BranchName).FirstOrDefault(),
                        Gender = _context.Genders.Where(x => x.GenderId==student.GenderId).Select(y => y.GenderName).FirstOrDefault()
                    };
                    studentList.Add(studentModel);
                }
            }
            return studentList;
        }

        public StudentModel GetStudent(int id)
        {
            var studentList = GetStudents();
            return studentList.Where(x => x.StudentId ==id).FirstOrDefault();
        }

        public int CreateStudent(StudentModel student)
        {
            B97Context _context = new B97Context();

            var genderId = _context.Genders.Where(x => x.GenderName == student.Gender).Select(y => y.GenderId).FirstOrDefault();
            var branchId = _context.Branches.Where(x => x.BranchName == student.BranchName).Select(y => y.BranchId).FirstOrDefault();

            Student student1 = new Student();
            student1.StudentName = student.StudentName;
            student1.StudentDateofBirth = student.StudentDateofBirth;
            student1.GenderId=genderId;
            student1.BranchId = branchId;
            
            _context.Students.Add(student1);
            _context.SaveChanges();
            return student1.StudentId;

        }

        public bool UpdateStudent(StudentModel studentModel)
        {
            B97Context _context = new B97Context();

            var student = _context.Students.Where(x => x.StudentId == studentModel.StudentId).FirstOrDefault();
            if(student != null)
            {
                student.StudentDateofBirth = studentModel.StudentDateofBirth;

                _context.Students.Update(student);
                var i = _context.SaveChanges();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool DeleteStudent(int studentId)
        {
            B97Context _context = new B97Context();
            var student = _context.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                var i = _context.SaveChanges();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
