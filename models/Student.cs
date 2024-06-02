using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models;

public class Student {

    public Student(string firstName, string surname, string phoneNumber, string cpf, string address, DateTime birthDate) {
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
    public DateTime BirthDate { get; set; }

    public int? UserId { get; set; }

    public User? User { get; set; }

    public int? CourseId { get; set; }

    public Course? Course { get; set; }
}
