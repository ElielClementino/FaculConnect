using Data;
using Microsoft.EntityFrameworkCore;
using Requests;
using Dtos;

namespace Services {

    public class LoginService {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, UserDto? User, string? ErrorMessage)> LoginAsync(LoginAccountRequest request, CancellationToken ct) {
            var user = await _context.Users
            .FirstOrDefaultAsync(user => user.Email == request.Email && user.Password == request.Password);

            if (user == null) {
                return(false, null!, "Email ou senha incorretos.");
            }

            var userDto = new UserDto(user.UserId, user.Username);

            return (true, userDto, null);
        }
    }
}
