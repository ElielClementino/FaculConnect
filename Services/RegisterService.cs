using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Requests;
using Dtos;

namespace Services {

    public class RegisterService {
        private readonly AppDbContext _context;

        public RegisterService(AppDbContext context) {
            _context = context;
        }

        public async Task<(bool IsSuccess, UserDto, string? ErrorMessage)> RegisterAccountAsync(RegisterAccountRequest request, CancellationToken ct) {
            try {

            var accountExists = await _context.Users
            .AnyAsync(user => user.Email == request.Email, ct);

            if (accountExists) {
                return(false, null!, "Já existe uma conta com esse endereço de email.");
            }

            var newUser = new User(request.Username, request.Password, request.Email);

            await _context.Users.AddAsync(newUser, ct);
            await _context.SaveChangesAsync(ct);

            var userDto = new UserDto(newUser.UserId, newUser.Username);

            return(true, userDto, null);
            } catch(Exception e) {
                return (false, null!, $"Ocorreu um erro ao criar a conta: {e.Message}");
            }
        }
    }
}
