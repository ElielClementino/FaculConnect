namespace Requests;

public record CreateCourseRequest(string Name, string Description, double Price, bool Availability) {}
