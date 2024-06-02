using System.ComponentModel.DataAnnotations;

namespace models;

public class User {

    public User(String username, String password, String email) {
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
