using FluentValidation.AspNetCore;
using Library.Service.Application.Interfaces;
using Library.Service.Application.Mappers;
using Library.Service.Application.Services;
using Library.Service.Application.Validators;

namespace Library.Service.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuthorMapper), typeof(BookMapper));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthorForCreationDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthorForCreationWithDateOfDeathDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthorsResourceParametersValidator>());

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookForCreationDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookForUpdateDtoValidator>());

            services.AddTransient<IValidationService, ValidationService>();
            services.AddScoped<ILibraryApplicationService, LibraryApplicationService>();

        }
    }
}
