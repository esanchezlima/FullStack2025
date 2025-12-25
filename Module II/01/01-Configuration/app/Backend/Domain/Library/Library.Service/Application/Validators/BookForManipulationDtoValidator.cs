using FluentValidation;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Validators
{
    public class BookForManipulationDtoValidator<T> : AbstractValidator<T> where T : BookForManipulationDto
    {
        public BookForManipulationDtoValidator()
        {            
        }
    }
}
