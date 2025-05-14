using Microsoft.AspNetCore.Components.Web;
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
		private static Dictionary<Type, string> components=new Dictionary<Type, string>();

        public static IServiceCollection RegisterGoldenLayoutService(this IServiceCollection services, Dictionary<Type, string> components)
		{
			Extension.components = components;
			return  services.AddSingleton(sp => new GoldenLayoutComponentService(components)).
				AddSingleton<GoldenLayoutEventService>().
				AddSingleton<GoldenLayoutSolveRegisterService>();
        }
		public static void RegisterGoldenLayoutComponent(this IJSComponentConfiguration configuration)
		{
			foreach(var item in components)
			{
				configuration.RegisterForJavaScript(item.Key, item.Value);
			}
		}
    }
}
