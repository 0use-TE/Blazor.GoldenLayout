# 🌟 欢迎使用 Blazor.GoldenLayout

## 🇨🇳 中文版本

你好，我是 **Ouse**，欢迎访问这个库！

这是一个 **Blazor 封装 GoldenLayout.js 的组件库**，它让你可以在 Blazor 项目中轻松实现类似 IDE 的可拖拽分栏布局。
 特别感谢 GoldenLayout 开发团队的出色工作！👏

![image](assets/image-20250514234024670.png)

------

## ✨ 快速开始

### 1️⃣ 安装 NuGet 包

```bash
NuGet\Install-Package Blazor.GoldenLayout -Version 1.0.0
```

------

### 2️⃣ 添加主题样式

只需添加你喜欢的主题样式，JS 文件将在运行时动态加载。
 对于 **Blazor Wasm** 项目，请在 `wwwroot/index.html` 中添加：

```html
<link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
```

对于 **Blazor Server** 项目（.NET 8 Blazor Web App），请在 `App.razor` 的 `<head>` 中添加同样的链接：

```html
<head>
    <link type="text/css" rel="stylesheet" href="_content/Blazor.GoldenLayout/goldenlayout-dark-theme.css" />
</head>
```

------

### 3️⃣ 注册组件服务

在 `Program.cs` 中注册你的组件类型和名称（名称用于 GoldenLayout 配置）：

#### ✅ Blazor WebAssembly：

```csharp
builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
{
    { typeof(Counter), "Counter"},
    { typeof(HelloWorld), "HelloWorld"},
});
builder.RootComponents.RegisterGoldenLayoutComponent();
```

#### ✅ Blazor Server：

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

### 4️⃣ 关闭预渲染（如果你开启了）

**如果你启用了预渲染功能（Prerendering），你需要关闭它**，否则会导致组件被重复注册。目前预渲染的支持正在开发中。你可以选择全局关闭或仅对当前页面关闭：

#### ✅ 全局禁用预渲染（Blazor Web App）：

```html
<body>
    <Routes @rendermode="@(new InteractiveServerRenderMode(prerender: false))" />
    <script src="_framework/blazor.web.js"></script>
</body>
```

------

### 5️⃣ 使用方式

支持两种方式：

- 🧩 Razor 组件方式（声明式配置）
- 🔧 代码方式（纯 C# 配置）

------

### 🧩 Razor 声明式配置示例：

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
            <GoldenLayoutComponent ComponentName="Counter" Title="计数器" />
            <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello" />
            <GoldenLayoutComponent ComponentName="Counter" Title="计数器" />
        </GoldenLayoutStack>
        <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello" />
        <GoldenLayoutComponent ComponentName="HelloWorld" Title="Hello" />
    </GoldenLayoutRow>
</GoldenLayout>
```

------

### 🔧 代码配置示例：

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
                        Title = "计数器",
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

## 🧠 原理介绍

本项目通过 Blazor 封装对 JavaScript 的操作，同时支持声明式配置布局结构，使得组件更贴合 Blazor 风格。

*未完待续...*

------

## 📚 API 文档

正在编写中，敬请期待！

------

## 🌈 项目未来计划

- ✅ 添加更多 GoldenLayout API 封装
- ✅ 提供示例项目和 GitHub Pages 预览
- 🔄 支持预渲染（Prerender）的自动适配
- ✅ 支持懒加载和动态组件注册
- 🚀 欢迎提交 PR 或 issue！

