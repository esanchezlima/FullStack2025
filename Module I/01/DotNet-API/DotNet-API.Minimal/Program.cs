using DotNet_API.Minimal.Application;
using DotNet_API.Minimal.Infrastructure.Data;
using DotNet_API.Minimal.Infrastructure.Extensions;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/people", (IPersonService personService) =>
//{
//    return personService.GetPeople();
//});

//app.MapGet("/people",() =>
//{
//    return "Hello World";
//});

app.RegisterPeopleEndpoints();
app.UseHttpsRedirection();
app.Run();
