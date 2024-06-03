using Data;
using Services;
using Requests;

namespace Endpoints {
    public static class CourseEndpoint {
        public static void CreateCourseEndpoint(this WebApplication app) {
            var CourseEndpoint = app.MapGroup("course");

            CourseEndpoint.MapPost("/create", async(CreateCourseRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var courseService = new CourseService(context);
                    var result = await courseService.CourseAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/course/{result.CourseDto?.CourseId}", result.CourseDto);
                    }

                    return Results.Problem(detail: result.ErrorMessage);
                } catch(Exception e) {
                    return Results.Problem($"Ocorreu um erro ao efetuar o cadastro  do curso: {e}");
                }
            });
            CourseEndpoint.MapGet("/list", async (AppDbContext context, CancellationToken ct) => {
                try {
                    var courseService = new CourseService(context);
                    var courses = await courseService.GetCoursesAsync(ct);

                    return Results.Ok(courses);
                }
                catch (Exception e) {
                    return Results.Problem($"Ocorreu um erro ao listar os cursos: {e}");
                }
            });
        }
    }
}
