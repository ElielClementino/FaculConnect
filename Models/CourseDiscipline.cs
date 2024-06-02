using System.ComponentModel.DataAnnotations;

namespace Models;

public class CourseDiscipline {

    [Key]
    public int CourseDisciplineId { get; set; }
    public int? CourseId { get; set; }
    public Course? Course { get; set; }

    public int? DisciplineId { get; set; }
    public Discipline? Discipline {get; set; }
}