## 👉 [查看中文文档](README_cn.md)

- 🌟 Welcome to Blazor.GoldenLayout

  Hello, I'm **Ouse**, and welcome to this library!

  This is a **Blazor wrapper for GoldenLayout.js**, enabling you to easily implement draggable, IDE-like split-panel layouts in your Blazor projects.  
  Special thanks to the GoldenLayout development team for their amazing work! 👏

  ![image](assets/image-20250514234024670.png)

  ------

  ## ✨ Quick Start

  ### 1️⃣ Install the NuGet Package

  ```bash
  NuGet\Install-Package Blazor.GoldenLayout -Version 1.0.0
  ```

  ------

  ### 2️⃣ Add Theme Styles

  Simply add your preferred theme stylesheet, and the JS file will be dynamically loaded at runtime.  
  For **Blazor WASM** projects, add the following to `wwwroot/index.html`:

  ```html
  <link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
  ```

  For **Blazor Server** projects (.NET 8 Blazor Web App), add the same link to the `<head>` section in `App.razor`:

  ```html
  <head>
      <link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
  </head>
  ```

  ------

  ### 3️⃣ Register Component Services

  In `Program.cs`, register your component types and their names (used in GoldenLayout configuration):

  #### ✅ Blazor WebAssembly:

  ```csharp
  builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
  {
      { typeof(Counter), "Counter"},
      { typeof(HelloWorld), "HelloWorld"},
  });
  builder.RootComponents.RegisterGoldenLayoutComponent();
  ```

  #### ✅ Blazor Server:

  ```csharp
  builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
  {
      { typeof(Counter), "Counter"},
      { typeof(HelloWorld), "HelloWorld"},
  });
  
  builder.Services.AddServerSideBlazor(options =>
  {
      options.RootComponents.RegisterGoldenLayoutComponent();
  });
  ```

  ------

  ### 4️⃣ Disable Prerendering (If Enabled)

  **If prerendering is enabled, you need to disable it**, as it may cause components to be registered multiple times. Prerendering support is currently under development. You can disable it globally or for specific pages:

  #### ✅ Globally Disable Prerendering (Blazor Web App):

  ```html
  <body>
      <Routes @rendermode="@(new InteractiveServerRenderMode(prerender: false))" />
      <script src="_framework/blazor.web.js"></script>
  </body>
  ```

  ------

  ### 5️⃣ Usage

  Two approaches are supported:

  - 🧩 Razor Component Approach (Declarative Configuration)
  - 🔧 Code-Based Approach (Pure C# Configuration)

  ------

  ### 🧩 Razor Declarative Configuration Example:

  ```csharp
  <GoldenLayoutSpawner>
      <div style="width:1000px;display: flex; gap: 12px; padding: 8px 12px; justify-content: center; background-color: #f9f9f9; border-radius: 8px; align-items: center;">
          <GoldenLayoutSpawnerItem ContentItem="_counter">ByDrag</GoldenLayoutSpawnerItem>
          <GoldenLayoutSpawnerItem ContentItem="_hello" SpawnerType="GoldenLayoutSpawnerType.BySelection">BySelection</GoldenLayoutSpawnerItem>
      </div>
  </GoldenLayoutSpawner>
  
  <GoldenLayout Style="width:1000px;height:800px" GoldenLayoutConfiguration="_configuration" SelectionChangedCallback="SelectionChangedCallback">
      <GoldenLayoutRow Title="Row">
          <GoldenLayoutStack>
              <GoldenLayoutComponent ComponentName="Counter" Title="Counter" />
              <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello" />
              <GoldenLayoutComponent ComponentName="Counter" Title="Counter" />
          </GoldenLayoutStack>
          <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello" />
          <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello" />
      </GoldenLayoutRow>
  </GoldenLayout>
  ```

  ------

  ### 🔧 Code-Based Configuration Example:

  ```csharp
  @page "/SimpleExample"
  @using Blazor.GoldenLayout
  <PageTitle>SimpleExample</PageTitle>
  
  <GoldenLayout Style="width:600px;height:400px" GoldenLayoutConfiguration="layoutConfig" />
  
  @code {
      private GoldenLayoutConfiguration layoutConfig = new()
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
                          Title = "Counter",
                          ComponentState = new Dictionary<string, object> { { "Cnt", 123 } }
                      },
                      new ContentItem
                      {
                          ContentType = ContentType.Component,
                          ComponentName = "Counter",
                          ComponentState = new Dictionary<string, object> { { "Cnt", 100 } }
                      },
                      new ContentItem
                      {
                          ContentType = ContentType.Component,
                          ComponentName = "Counter",
                          ComponentState = new Dictionary<string, object> { { "Cnt", 10 } }
                      }
                  }
              }
          }
      };
  }
  ```

  ------

  ## 🧠 How It Works

  This project wraps JavaScript operations with Blazor, while supporting declarative layout configuration, making the component more aligned with the Blazor style.

  *To be continued...*

  ------

  ## 📚 API Documentation

  Documentation is under development. Stay tuned!

  ------

  ## 🌈 Future Plans

  - ✅ Add more GoldenLayout API wrappers
  - ✅ Provide sample projects and GitHub Pages previews
  - 🔄 Support automatic adaptation for prerendering
  - ✅ Support lazy loading and dynamic component registration
  - 🚀 Contributions via PRs or issues are welcome!

  
