using System.ComponentModel.DataAnnotations;

namespace Models;

public class Lesson {
    public Lesson(string name) {
        Name = name;
    }

    [Key]
    public int LessonId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; }
    public int? DisciplineId { get; set; }
    public Discipline? Discipline {get; set; }
}
