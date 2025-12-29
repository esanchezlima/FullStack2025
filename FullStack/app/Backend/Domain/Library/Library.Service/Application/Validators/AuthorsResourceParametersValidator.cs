using FluentValidation;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Validators
{
    public class AuthorsResourceParametersValidator: AbstractValidator<AuthorsResourceParameters>
    {
        public AuthorsResourceParametersValidator()
        {
            RuleFor(x => x.Fields).Custom((fields, context) =>
            {
                if (!string.IsNullOrEmpty(fields))
                {
                    var fieldList = fields.Split(',');
                    if (!fieldList.Any(f => f.Trim().Equals("AuthorId", StringComparison.OrdinalIgnoreCase)))
                    {
                        context.InstanceToValidate.Fields = fields + ",AuthorId";
                    }
                }
            });
        }
    }
}
