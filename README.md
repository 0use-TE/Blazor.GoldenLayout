## 👉 [查看中文文档](README_cn.md)

Hi, I'm **Ouse**. Welcome to this library!

This is a **Blazor wrapper for GoldenLayout.js**, which helps you create dockable, resizable layouts in your Blazor applications.
 A huge thanks to the GoldenLayout team for their amazing work! 🙌

------

### ✨ Quick Start

#### 1️⃣ Install NuGet Package

```bash
Install-Package Blazor.GoldenLayout
```

#### 2️⃣ Add Theme CSS

Add your preferred theme to `index.html` (Blazor Wasm) or `App.razor` (Blazor Web App).
 JS files will be injected dynamically.

**Example (dark theme):**

```html
<link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
```

#### 3️⃣ Register Components

In `Program.cs`, register your components like this:

**For Blazor WebAssembly:**

```csharp
builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
{
    { typeof(Counter), "Counter"},
    { typeof(HelloWorld), "HelloWorld"},
});
builder.RootComponents.RegisterGoldenLayoutComponent();
```

**For Blazor Server:**

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

#### 4️⃣ Disable Prerendering (If enabled)

Due to lifecycle differences, **prerendering must be disabled** for now to avoid duplicate component registration.

```html
<body>
    <Routes @rendermode="@(new InteractiveServerRenderMode(prerender: false))" />
    <script src="_framework/blazor.web.js"></script>
</body>
```

------

### 🧩 Razor-Based Layout Example

See the Chinese version above for a detailed Razor example.

------

### 🔧 C#-Based Layout Configuration

Also see the code example in the Chinese section.

------

### 💡 How It Works

This library is built as a Blazor wrapper over GoldenLayout's JavaScript API, but supports **declarative Razor syntax** to make layout definition more Blazor-friendly.

*More technical documentation coming soon!*

------

### 🔮 Roadmap

- More API coverage
- GitHub Pages + live preview
- Automatic handling of prerendering
- Lazy loading + component registry improvements
