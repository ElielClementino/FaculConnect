using Data;
using Dtos;
using Models;
using Routes;

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
    }
}
