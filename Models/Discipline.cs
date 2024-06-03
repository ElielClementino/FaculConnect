using System.ComponentModel.DataAnnotations;

namespace Models;

public class Discipline {

    public Discipline(string name) {
        Name = name;
    }

    [Key]
    public int DisciplineId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

}