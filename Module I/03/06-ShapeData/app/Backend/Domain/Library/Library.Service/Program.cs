using Library.Service.Application.Extensions;
using Library.Service.Infrastructure.Extensions;
using Library.Service.Infrastructure.Http.Extensions;
using Library.Service.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LibraryConnectionString");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(opt => opt.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.RegisterEndpoints();
app.UseSeedData();
app.Run();
