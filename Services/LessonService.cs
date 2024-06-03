using Data;
using Models;
using Dtos;
using Requests;
using Microsoft.EntityFrameworkCore;

namespace Services {

    public class LessonService {
        private readonly AppDbContext _context;

        public LessonService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, LessonDto? LessonDto, string? ErrorMessage)> LessonAsync(CreateLessonRequest request, CancellationToken ct) {
            try {
                var newLesson = new Lesson(request.Name)
                {
                    DisciplineId = request.DisciplineId
                };

                await _context.Lessons.AddAsync(newLesson, ct);
                await _context.SaveChangesAsync(ct);

                var LessonDto = new LessonDto(newLesson.LessonId, newLesson.Name, newLesson.DisciplineId);

                return (true, LessonDto, null);
            } catch (Exception e) {
                return (false, null, $"Ocorreu um erro ao criar a aula: {e.Message}");
            }
        }


        public async Task<List<LessonDto>> GetLessonsAsync(int disciplineId, CancellationToken ct) {
            var lessons = await _context.Lessons
                .Where(lesson => lesson.DisciplineId == disciplineId)
                .Select(lesson => new LessonDto(lesson.LessonId, lesson.Name, lesson.DisciplineId))
                .ToListAsync(ct);

            return lessons;
        }
    }
}
