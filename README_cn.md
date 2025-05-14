你好，我是Ouse，欢迎您访问这个库！
这是一个Blazor对goldenlayout.js封装的库，非常感谢goldenlayout开发团队的工作！

x![image-20250514234024670](assets/image-20250514234024670.png)

### 简单使用

1. 安装Nuget包

   ```bash
   NuGet\Install-Package Blazor.GoldenLayout -Version 1.0.0
   ```

2. 添加您喜欢的主题到index.html(Blazor Wasm)或者App.razor(Blazor Web App)
   该项目默认包含了明亮两套主题
   goldenlayout等需要的js文件会在您使用时动态添加，您只需要添加主题样式即可

   index.html

   ```html
   <!DOCTYPE html>
   <html lang="en">
   <head>
       <meta charset="utf-8" />
       <meta name="viewport" content="width=device-width, initial-scale=1.0" />
       <title>GoldenLayoutTest</title>
       <base href="/" />
       <link rel="stylesheet" href="css/app.css" />
       <link rel="icon" type="image/png" href="favicon.png" />
       <link href="GoldenLayoutTest.styles.css" rel="stylesheet" />
       <!--here add the theme css-->
       <link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
       <!--or-->
       <!--<link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />-->
   </head>
   
   <body>
       <div id="app">
           <svg class="loading-progress">
               <circle r="40%" cx="50%" cy="50%" />
               <circle r="40%" cx="50%" cy="50%" />
           </svg>
           <div class="loading-progress-text"></div>
       </div>
   
       <div id="blazor-error-ui">
           An unhandled error has occurred.
           <a href="" class="reload">Reload</a>
           <a class="dismiss">🗙</a>
       </div>
       <script src="_framework/blazor.webassembly.js"></script>
   </body>
   
   </html>
   ```

   App.raozr

   ```html
   <!DOCTYPE html>
   <html lang="en">
   
   <head>
       <meta charset="utf-8"/>
       <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
       <base href="/"/>
       <link rel="stylesheet" href="@Assets["lib/bootstrap/dist/css/bootstrap.min.css"]"/>
       <link rel="stylesheet" href="@Assets["app.css"]"/>
       <link rel="stylesheet" href="@Assets["BlazorServer_Test.styles.css"]"/>
       <ImportMap/>
       <link rel="icon" type="image/png" href="favicon.png"/>
       <HeadOutlet/>
       <!--here add the theme css-->
       <link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
       <!--or-->
       <!--<link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />-->
   </head>
   
   <body>
   <Routes  @rendermode="@(new InteractiveServerRenderMode(prerender:false))"/>
   <script src="_framework/blazor.web.js"></script>
   </body>
   
   </html>
   ```

   

3. 添加需要的服务

   对于BlazorWasm

   ```c#
   using Blazor.GoldenLayout;
   using GoldenLayoutTest;
   using GoldenLayoutTest.Pages;
   using Microsoft.AspNetCore.Components.Web;
   using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
   
   var builder = WebAssemblyHostBuilder.CreateDefault(args);
   builder.RootComponents.Add<App>("#app");
   builder.RootComponents.Add<HeadOutlet>("head::after");
   
   builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
   
   //Start
   builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
   {
       { typeof(Counter), "Counter"},
       {typeof(HelloWorld),"HelloWorld"},
   });
   builder.RootComponents.RegisterGoldenLayoutComponent();
   //End
   await builder.Build().RunAsync();
   
   ```

   对于BlazorServer

   ```csharp
   using Blazor.GoldenLayout;
   using BlazorServer_Test.Components;
   using BlazorServer_Test.Components.Pages;
   using Microsoft.AspNetCore.Components.Web;
   
   var builder = WebApplication.CreateBuilder(args);
   
   // Add services to the container.
   builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();
   
   
   //Start
   builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
   {
       { typeof(Counter), "Counter"},
       {typeof(HelloWorld),"HelloWorld"},
   });
   
   builder.Services.AddServerSideBlazor(options =>
   {
       options.RootComponents.RegisterGoldenLayoutComponent();
   });
   //End
   var app = builder.Build();
   
   // Configure the HTTP request pipeline.
   if (!app.Environment.IsDevelopment())
   {
       app.UseExceptionHandler("/Error", createScopeForErrors: true);
       // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
       app.UseHsts();
   }
   
   app.UseHttpsRedirection();
   
   
   app.UseAntiforgery();
   
   app.MapStaticAssets();
   app.MapRazorComponents<App>()
       .AddInteractiveServerRenderMode();
   
   app.Run();
   ```

4. 如果您的项目没有开启预渲染，可以跳过这一步，否则，您必须关闭预渲染
   因为raozr组件进行配置，是通过级联参数获取父节点，然后再将您传入的参数传递到父节点的列表里面，每个组件的OnInitialized回调是异步的，因此即使GoldenLayout容器里面是在OnAfterRenderAsync回调里进行渲染，仍有可能出现配置尚问完成便开始渲染，所以我使用了一个全局单例类解决这个问题，所有子节点会自动注册到该类的字典属性里面，让值加一，然后OnAfterRenderAsync回调里面再发布完成事件，单例类会对比注册次数和完成次数，只有都完成了才会通知GoldenLayout组件进行渲染，因此，如果您开启了预渲染便会导致计数出错，我在尝试解决这个问题，所以在此之前请关闭预渲染，如下，我全局禁用了预渲染。

   ```html
   <body>
   <Routes  @rendermode="@(new InteractiveServerRenderMode(prerender:false))"/>
   <script src="_framework/blazor.web.js"></script>
   </body>
   ```

   

5. 使用！

   令人兴奋的是，该项目同时支持razor组件配置和代码配置，但是当您使用了raozr组件配置时，在外部配置的GoldenLayoutConfigure的ContentItem属性将不起作用，我们后面会介绍😋

   下面都是基本的使用，您可以查看其它页面！

   Razor组件配置 

   ```html
       <div style="width:1000px;display: flex; gap: 12px; padding: 8px 12px; justify-content: center; background-color: #f9f9f9; border-radius: 8px; align-items: center;">
           <GoldenLayoutSpawnerItem ContentItem="_counter">ByDrag</GoldenLayoutSpawnerItem>
           <GoldenLayoutSpawnerItem ContentItem="_hello" SpawnerType="GoldenLayoutSpawnerType.BySelection">BySelection</GoldenLayoutSpawnerItem>
       </div>
   </GoldenLayoutSpawner>
   
   <GoldenLayout Style="width:1000px;height:800px" GoldenLayoutConfiguration="_configuration" SelectionChangedCallback="SelectionChangedCallback">
       <GoldenLayoutRow Title="Row">
           
           <GoldenLayoutStack>
               <GoldenLayoutComponent ComponentName="Counter" Title="计数器"></GoldenLayoutComponent>
               <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello"></GoldenLayoutComponent>
               <GoldenLayoutComponent ComponentName="Counter" Title="计数器"></GoldenLayoutComponent>
           </GoldenLayoutStack>
   
           <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello"></GoldenLayoutComponent>
           <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello"></GoldenLayoutComponent>
       </GoldenLayoutRow>
   </GoldenLayout>
   ```

   代码配置

   ```csharp
   @page "/SimpleExample"
   @using Blazor.GoldenLayout
   <PageTitle>SimpleExample</PageTitle>
   
   <GoldenLayout Style="width:600px;height:400px"  GoldenLayoutConfiguration="layoutConfig" >
   </GoldenLayout>
   
   @code{
   
       private  GoldenLayoutConfiguration layoutConfig = new GoldenLayoutConfiguration
           {
               Content = new List<ContentItem>
       {
           new ContentItem
           {
               ContentType = ContentType.Row,
               Content = new List<ContentItem>
               {
                   new ContentItem
                   {
                       ContentType = ContentType.Component,
                       ComponentName = "Counter",
                       Title="计数器",
                       ComponentState=new Dictionary<string, object>
                       {
                           {"Cnt",123 }
                       }
                   },
                   new ContentItem
                   {
                       ContentType = ContentType.Component,
                       ComponentName = "Counter",
                       ComponentState=new Dictionary<string, object>
                       {
                           {"Cnt",100 }
                       }
                   },
                   new ContentItem
                   {
                       ContentType = ContentType.Component,
                       ComponentName = "Counter",
                             ComponentState=new Dictionary<string, object>
                       {
                           {"Cnt",10 }
                       }
                   }
               }
           }
                   }
           };
     
   }
   ```

   

### 原理介绍

正在编写

### 部分Api

正在编写

### 未来

1. 添加更多的api封装
2. 添加一个github pages
3. 能够处理预渲染的问题

