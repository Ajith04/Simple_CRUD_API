using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.IServices;
using DotNetCRUD.Models;
using DotNetCRUD.Repositories;

namespace DotNetCRUD.Services
{
    public class Student_Services : IStudent_Services
    {
        private readonly IStudent_Repo _studentRepo;

        public Student_Services(IStudent_Repo studentRepo)
        {
            _studentRepo = studentRepo;
        }


        public async Task<Student_ResponseDTO> AddStudent(Student_RequestDTO student)
        {
            var newStudent = new Student
            {
                StudentFirstName = student.StudentFirstName,
                StudentLastName = student.StudentLastName,
                StudentDOB = student.StudentDOB,
                StudentPhone = student.StudentPhone,
                StudentAddress = student.StudentAddress,
                StudentGender = student.StudentGender,
                StudentEmail = student.StudentEmail
            };

            var addedStudent = await _studentRepo.AddStudent(newStudent);

            return new Student_ResponseDTO
            {
                StudentId = addedStudent.StudentId,
                StudentFirstName = addedStudent.StudentFirstName,
                StudentLastName = addedStudent.StudentLastName,
                StudentDOB = addedStudent.StudentDOB,
                StudentPhone = addedStudent.StudentPhone,
                StudentAddress = addedStudent.StudentAddress,
                StudentGender = addedStudent.StudentGender,
                StudentEmail = addedStudent.StudentEmail
            };
        }



        public async Task<Student_ResponseDTO> GetStudentById(int id)
        {
            var student = await _studentRepo.GetByIdStudent(id);
            if (student == null)
            {
                return null;
            }

            return new Student_ResponseDTO
            {
                StudentId = student.StudentId,
                StudentFirstName = student.StudentFirstName,
                StudentLastName = student.StudentLastName,
                StudentDOB = student.StudentDOB,
                StudentPhone = student.StudentPhone,
                StudentAddress = student.StudentAddress,
                StudentGender = student.StudentGender,
                StudentEmail = student.StudentEmail
            };
        }

        public async Task<IEnumerable<Student_ResponseDTO>> GetAllStudents()
        {
            var students = await _studentRepo.GetAllStudent();
            return students.Select(student => new Student_ResponseDTO
            {
                StudentId = student.StudentId,
                StudentFirstName = student.StudentFirstName,
                StudentLastName = student.StudentLastName,
                StudentDOB = student.StudentDOB,
                StudentPhone = student.StudentPhone,
                StudentAddress = student.StudentAddress,
                StudentGender = student.StudentGender,
                StudentEmail = student.StudentEmail
            });
        }

        public async Task<Student_ResponseDTO> UpdateStudent(int id, Student_RequestDTO student)
        {
            var existingStudent = await _studentRepo.GetByIdStudent(id);
            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.StudentFirstName = student.StudentFirstName;
            existingStudent.StudentLastName = student.StudentLastName;
            existingStudent.StudentDOB = student.StudentDOB;
            existingStudent.StudentPhone = student.StudentPhone;
            existingStudent.StudentAddress = student.StudentAddress;
            existingStudent.StudentGender = student.StudentGender;
            existingStudent.StudentEmail = student.StudentEmail;

            var updatedStudent = await _studentRepo.UpdateStudent(existingStudent);

            return new Student_ResponseDTO

            {
                StudentId = updatedStudent.StudentId,
                StudentFirstName = updatedStudent.StudentFirstName,
                StudentLastName = updatedStudent.StudentLastName,
                StudentDOB = updatedStudent.StudentDOB,
                StudentPhone = updatedStudent.StudentPhone,
                StudentAddress = updatedStudent.StudentAddress,
                StudentGender = updatedStudent.StudentGender,
                StudentEmail = updatedStudent.StudentEmail
            };
        }

        public async Task<bool> DeleteStudent(int id)
        {
            await _studentRepo.DeleteStudent(id);
            return true;
        }




    }


}
