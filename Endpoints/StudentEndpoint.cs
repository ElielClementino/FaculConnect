using Data;
using Routes;
using Services;

namespace Endpoints {
    public static class StudentEndpoint {
        public static void CreateStudentEndpoint(this WebApplication app) {
            var studentEndpoint = app.MapGroup("student");

            studentEndpoint.MapPost("/create", async(CreateStudentRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var studentService = new StudentService(context);
                    var result = await studentService.StudentAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/register/{result.StudentDto?.StudentId}", result.StudentDto);
                    }

                    return Results.Problem(detail: result.ErrorMessage);
                } catch(Exception e) {
                    return Results.Problem($"Ocorreu um erro ao efetuar o cadastro  do estudante: {e}");
                }
            });
        }
    }
}
