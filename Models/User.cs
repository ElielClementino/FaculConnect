using System.ComponentModel.DataAnnotations;

namespace Models;

public class User {

    public User(string username, string password, string email) {
        Username = username;
        Password = password;
        Email = email;
        CreatedAT = DateTime.UtcNow;
    }

    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }
    public DateTime CreatedAT { get; set; }
}
