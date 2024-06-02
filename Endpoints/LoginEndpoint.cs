using Data;
using Services;

namespace Endpoints {

    public static class LoginEndpoint {
        public static void LoginAccountEndpoint(this WebApplication app) {
            var LoginEndpoint = app.MapGroup("login");

            LoginEndpoint.MapPost("", async(LoginAccountRequest request, AppDbContext context, CancellationToken ct) => {
                try {
                    var loginService = new LoginService(context);
                    var result = await loginService.LoginAsync(request, ct);

                    if (result.IsSuccess) {
                        return Results.Ok(result.User);
                    }

                    return Results.Unauthorized();

                } catch(Exception e) {
                    return Results.Problem($"Ocorreu um erro ao fazer o login: {e}");
                }
            });
        }
    }
}
