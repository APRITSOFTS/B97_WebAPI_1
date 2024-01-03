namespace B97_WebAPI.Models.Repository
{
    public interface IStudentRepository
    {
        List<StudentModel> GetStudents();
        StudentModel GetStudent(int id);
        int CreateStudent(StudentModel student);
        bool UpdateStudent(StudentModel studentModel);
        bool DeleteStudent(int studentId);
    }
}