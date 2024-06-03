using Data;
using Services;
using Requests;

namespace Endpoints {
    public static class RegisterEndpoint {
        public static void RegisterAccountEndpoint(this WebApplication app) {
            var RegisterEndpoint = app.MapGroup("register");

            RegisterEndpoint.MapPost("", async (RegisterAccountRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var registerService = new RegisterService(context);
                    var result = await registerService.RegisterAccountAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Created($"/register/{result.Item2.UserId}", result.Item2);
                    }

                    return Results.Conflict(result.ErrorMessage);
                } catch(Exception e) {
                    return Results.Problem($"Ocorreu um erro ao criar a conta: {e}");
                }
            });
        }
    }
}
