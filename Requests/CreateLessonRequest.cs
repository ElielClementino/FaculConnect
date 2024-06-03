namespace Requests;

public record CreateLessonRequest(int LessonId, string Name, int? DisciplineId) {}

