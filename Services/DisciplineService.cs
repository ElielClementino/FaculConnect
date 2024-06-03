using Data;
using Dtos;
using Models;
using Requests;

namespace Services {

    public class DisciplineService {

        private readonly AppDbContext _context;

        public DisciplineService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, DisciplineDto? DisciplineDto, string? ErrorMessage)> DisciplineAsync(CreateDisciplineRequest request, CancellationToken ct) {
            try {
                var newDiscipline = new Discipline(request.Name, request.Semester) {
                    CourseId = request.CourseId
                };

                await _context.Disciplines.AddAsync(newDiscipline, ct);
                await _context.SaveChangesAsync(ct);

                var disciplineDto = new DisciplineDto(newDiscipline.DisciplineId, newDiscipline.Name, newDiscipline.Semester, newDiscipline.CourseId);

                return (true, disciplineDto, null);
            } catch (Exception e) {
                return (false, null, $"Ocorreu um erro ao criar a disciplina: {e.Message}");
            };
        }
    }
}
