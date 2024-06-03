using Data;
using Services;
using Requests;

namespace Endpoints {
    public static class CourseDisciplineEndpoint {
        public static void CreateCourseDisciplineEndpoint(this WebApplication app) {
            var courseDisciplineEndpoint = app.MapGroup("course-discipline");

            courseDisciplineEndpoint.MapPost("/create", async (CreateCourseDisciplineRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var courseDisciplineService = new CourseDisciplineService(context);
                    var result = await courseDisciplineService.CourseDisciplineAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/course-discipline/{result.CourseDisciplineDto?.CourseDisciplineId}", result.CourseDisciplineDto);
                    }
                    return Results.Problem(detail: result.ErrorMessage);
                } catch (Exception e) {
                    return Results.Problem($"Ocorreu um erro na criação da relação curso-disciplina: {e.Message}");
                }
            });
        }
    }
}
