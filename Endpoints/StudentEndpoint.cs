using Data;
using Services;
using Requests;

namespace Endpoints {
    public static class StudentEndpoint {
        public static void CreateStudentEndpoint(this WebApplication app) {
            var studentEndpoint = app.MapGroup("student");

            studentEndpoint.MapPost("/create", async(CreateStudentRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var studentService = new StudentService(context);
                    var result = await studentService.StudentAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/student/{result.StudentDto?.StudentId}", result.StudentDto);
                    }

                    return Results.Problem(detail: result.ErrorMessage);
                } catch(Exception e) {
                    return Results.Problem($"Ocorreu um erro ao efetuar o cadastro  do estudante: {e}");
                }
            });
            studentEndpoint.MapPut("/update-course", async (UpdateStudentCourseRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var studentService = new StudentService(context);
                    var result = await studentService.UpdateStudentCourseAsync(request.StudentId, request.CourseId, ct);

                    if (result.IsSuccess) {
                        return Results.Ok("Curso do estudante atualizado com sucesso.");
                    }

                    return Results.Problem(detail: result.ErrorMessage);
                } catch (Exception e) {
                    return Results.Problem($"Ocorreu um erro ao atualizar o curso do estudante: {e}");
                }
            });
            studentEndpoint.MapGet("{userId}", async (AppDbContext context, int userId, CancellationToken ct) => {
                try {
                    var studentService = new StudentService(context);
                    var result = await studentService.RetrieveStudentAsync(userId, ct);

                    if (result.IsSuccess) {
                        return Results.Ok(result.StudentDto);
                    }

                    return Results.Problem(detail: result.ErrorMessage);
                } catch (Exception e) {
                    return Results.Problem($"Ocorreu um erro ao buscar pelo estudante: {e}");
                }
            });
        }
    }
}
