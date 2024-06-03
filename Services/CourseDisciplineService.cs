using Data;
using Models;
using Dtos;

namespace Services {

    public class CourseDisciplineService {
        private readonly AppDbContext _context;

        public CourseDisciplineService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, CourseDisciplineDto? CourseDisciplineDto, string? ErrorMessage)> CourseDisciplineAsync(CreateCourseDisciplineRequest request, CancellationToken ct) {
            try {
                var newCourseDiscipline = new CourseDiscipline {
                    CourseId = request.CourseId,
                    DisciplineId = request.DisciplineId
                };

                await _context.CourseDisciplines.AddAsync(newCourseDiscipline, ct);
                await _context.SaveChangesAsync(ct);

                var courseDisciplineDto = new CourseDisciplineDto(newCourseDiscipline.CourseDisciplineId, newCourseDiscipline.CourseId, newCourseDiscipline.DisciplineId);

                return (true, courseDisciplineDto, null);
            } catch (Exception e) {
                return (false, null, $"Ocorreu um erro ao criar curso-disciplina: {e.Message}");
            }
        }
    }
}
