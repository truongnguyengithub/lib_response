using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OMC.Libs
{
    public static class StartUpExtensions
    {
        public static IServiceCollection AddApiCore(this IServiceCollection services)
        {
            services.AddScoped<IRequestContext, RequestContext>();
            return services;
        }

        public static void UseApiCore(this IApplicationBuilder app)
        {
            app.UseRequestContext();
        }

        private static void UseRequestContext(this IApplicationBuilder app) => app.Use(async (context, next) =>
        {
            ((RequestContext)context.RequestServices.GetRequiredService<IRequestContext>()).Context = context;
            await next();
        });
    }
}
