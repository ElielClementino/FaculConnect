using Data;
using Routes;
using Services;

namespace Endpoints {
    public static class DisciplineEndpoint {
        public static void CreateDisciplineEndpoint(this WebApplication app) {
            var disciplineEndpoint = app.MapGroup("discipline");

            disciplineEndpoint.MapPost("/create", async(CreateDisciplineRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var disciplineService = new DisciplineService(context);
                    var result = await disciplineService.DisciplineAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/register/{result.DisciplineDto?.DisciplineId}", result.DisciplineDto);
                    }

                    return Results.Problem(detail: result.ErrorMessage);
                } catch(Exception e) {
                    return Results.Problem($"Ocorreu um erro ao efetuar o cadastro  da disciplina: {e}");
                }
            });
        }
    }
}
