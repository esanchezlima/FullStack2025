using Library.Service.Application.Extensions;
using Library.Service.Domain.Extensions;
using Library.Service.Infrastructure.Extensions;
using Library.Service.Infrastructure.Http.EndpointHandlers;
using Library.Service.Infrastructure.Http.Extensions;
using Library.Service.Infrastructure.Persistence.Extensions;
using Library.Service.Infrastructure.Security.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LibraryConnectionString");

builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastructure(opt => opt.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterEndpoints();
app.UseSeedData();
app.Run();
