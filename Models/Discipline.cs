using System.ComponentModel.DataAnnotations;

namespace Models;

public class Discipline {

    public Discipline(string name, int semester) {
        Name = name;
        Semester = semester;
    }

    [Key]
    public int DisciplineId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public int Semester { get; set; }
    public int? CourseId { get; set; }
    public Course? Course { get; set; }
}