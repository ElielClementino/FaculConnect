using Data;
using Services;
using Requests;

namespace Endpoints {
    public static class LessonEndpoint {
        public static void CreateLessonEndpoint(this WebApplication app) {
            var lessonEndpoint = app.MapGroup("lesson");

            lessonEndpoint.MapPost("/create", async (CreateLessonRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var lessonService = new LessonService(context);
                    var result = await lessonService.LessonAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/lesson/{result.LessonDto?.LessonId}", result.LessonDto);
                    }
                    return Results.Problem(detail: result.ErrorMessage);
                } catch (Exception e) {
                    return Results.Problem($"Ocorreu um erro na criação da aula: {e.Message}");
                }
            });
        }
    }
}
