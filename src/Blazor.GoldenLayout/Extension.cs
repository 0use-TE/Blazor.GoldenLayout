using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
	 public static class Extension
	{
		public static IServiceCollection RegisterGoldenLayoutServices(this IServiceCollection services, Dictionary<Type, string> components)
		{
			// 注册 RegisterGoldenLayout 服务，并传递组件字典
			services.AddSingleton<RegisterGoldenLayout>(sp =>
			{

			});

			return services;
		}

	}
}
