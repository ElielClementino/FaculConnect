using Data;
using Dtos;
using Models;
using Requests;
using Microsoft.EntityFrameworkCore;

namespace Services {

    public class CourseService {

        private readonly AppDbContext _context;

        public CourseService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, CourseDto? CourseDto, string? ErrorMessage)> CourseAsync(CreateCourseRequest request, CancellationToken ct) {
            try {
                var newCourse = new Course(request.Name, request.Description, request.Price, request.Availability);

                await _context.Courses.AddAsync(newCourse, ct);
                await _context.SaveChangesAsync(ct);

                var CourseDto = new CourseDto(newCourse.CourseId, newCourse.Name, newCourse.Description, newCourse.Price, newCourse.Availability);

                return (true, CourseDto, null);
            } catch (Exception e) {
                return (false, null, $"Ocorreu um erro ao criar o curso: {e.Message}");
            };
        }

        public async Task<List<CourseDto>> GetCoursesAsync(CancellationToken ct) {
            var courses = await _context.Courses
            .Select(course => new CourseDto(course.CourseId, course.Name, course.Description, course.Price, course.Availability))
            .ToListAsync(ct);

            return courses;
        }
    }
}
