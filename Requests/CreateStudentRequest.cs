namespace Requests;

public record CreateStudentRequest(string FirstName, string Surname, string PhoneNumber, string Cpf, string Address, DateTime BirthDate, int UserId) {}