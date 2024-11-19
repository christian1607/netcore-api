using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			var assembly = typeof(DependencyContainer).Assembly;

			services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembly));
			services.AddValidatorsFromAssembly(assembly);

			return services;
		}
	}
}

