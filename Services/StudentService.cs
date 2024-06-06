using Data;
using Dtos;
using Models;
using Requests;
using Microsoft.EntityFrameworkCore;

namespace Services {

    public class StudentService {

        private readonly AppDbContext _context;

        public StudentService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, StudentDto? StudentDto, string? ErrorMessage)> StudentAsync(CreateStudentRequest request, CancellationToken ct) {
            try {
                var newStudent = new Student(request.FirstName, request.Surname, request.PhoneNumber, request.Cpf, request.Address, request.BirthDate);
                newStudent.UserId = request.UserId;

                await _context.Students.AddAsync(newStudent, ct);
                await _context.SaveChangesAsync(ct);

                var studentDto = new StudentDto(newStudent.StudentId, newStudent.FirstName, newStudent.Surname, newStudent.UserId);

                return (true, studentDto, null);
            } catch (Exception e) {
                return (false, null, $"Ocorreu um erro ao criar o estudante: {e.Message}");
            };
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStudentCourseAsync(int studentId, int courseId, CancellationToken ct) {
            try {
                var student = await _context
                .Students
                .FindAsync(new object[] { studentId }, ct);

                if (student == null) {
                    return (false, $"O estudante com o id {studentId} não foi encontrado.");
                }

                student.CourseId = courseId;

                _context.Students.Update(student);
                await _context.SaveChangesAsync(ct);

                return (true, null);
            } catch (Exception e) {
                return (false, $"Ocorreu um erro ao atualizar o curso do estudante: {e.Message}");
            }
        }

        public async Task<(bool IsSuccess, StudentDto ? StudentDto, string? ErrorMessage)> RetrieveStudentAsync(int userId, CancellationToken ct) {
            try {
                var student = await _context
                .Students
                .FirstOrDefaultAsync(student => student.UserId == userId, ct);

                if (student == null) {
                    return (false, null, $"O estudante com o id de usuário {userId} não foi encontrado.");
                }

                var studentDto = new StudentDto(student.StudentId, student.FirstName, student.Surname, student.UserId);

                return (true, studentDto, null);
            } catch (Exception e) {
                return (false, null, $"Ocorreu um erro ao buscar pelo estudante: {e.Message}");
            }
        }
    }
}
