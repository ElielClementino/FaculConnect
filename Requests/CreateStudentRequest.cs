namespace Requests;

public record CreateStudentRequest(string FirstName, string Surname, string PhoneNumber, string Cpf, string Address, string BirthDate, int UserId) {}
