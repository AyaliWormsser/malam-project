using HoursReport.Core.Repositories;
using HoursReport.Core.Services;
using HoursReport.Data;
using HoursReport.Data.Repositories;
using HoursReport.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWorkReportService, WorkReportService>();
builder.Services.AddScoped<IWorkReportRepository, WorkReportRepository>();
builder.Services.AddDbContext<DataContext>();

// Add CORS policy with a name
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // ����� �-Origin ��� ���� ����
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // �� �� ����
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // ����� UseRouting ���� UseCors

app.UseCors("AllowAllOrigins"); // ����� ������� ��� �����

app.UseAuthorization();

app.MapControllers();

app.Run();

