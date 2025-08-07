namespace KSProject.BackgroundServiceEx
{
	public static class RegistrationBackground
	{
		public static IServiceCollection AddBackGroundService<T>(this IServiceCollection services) where T : class, IBackgroundOperation
		{
			services.AddScoped<T>();
			services.AddHostedService<BackgroundServiceExample<T>>();
			return services;
		}
	}
}
