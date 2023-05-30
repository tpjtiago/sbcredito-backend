using FluentValidation.AspNetCore;
using SBcredito.Domain.Validators;

namespace SBcredito.API.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IMvcBuilder AddFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<TituloAnaliseValidator>();
            });

            return builder;
        }
    }
}
