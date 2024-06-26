using System.ComponentModel.DataAnnotations;

namespace Models;

public class Student {

    public Student(string firstName, string surname, string phoneNumber, string cpf, string address, string birthDate) {
        FirstName = firstName;
        Surname = surname;
        PhoneNumber = phoneNumber;
        Cpf = cpf;
        Address = address;
        BirthDate = birthDate;
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }

    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(11)]
    public string Cpf { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; }

    [Required]
    public string BirthDate { get; set; }

    public int? UserId { get; set; }

    public User? User { get; set; }

    public int? CourseId { get; set; }

    public Course? Course { get; set; }
}
