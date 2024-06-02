using System.ComponentModel.DataAnnotations;

namespace Models;

public class Course {

    public Course(string name, string description, double price, bool availability) {
        Name = name;
        Description = description;
        Price = price;
        Availability = availability;
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double Price { get; set; }

    public bool Availability { get; set; }

}