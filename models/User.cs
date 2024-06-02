namespace models;

public class User {

    public User() {
        CreatedAT = DateTime.UtcNow;
    }

    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAT { get; set; }
}
