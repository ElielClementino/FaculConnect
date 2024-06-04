using Data;
using Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FaculConnect", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FaculConnect");
app.UseHttpsRedirection();

// Endpoint configurations
app.RegisterAccountEndpoint();
app.LoginAccountEndpoint();
app.CreateStudentEndpoint();
app.CreateDisciplineEndpoint();
app.CreateCourseEndpoint();
app.CreateLessonEndpoint();

app.Run();
