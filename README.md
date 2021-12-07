# Hey ASP.NET Core

- [多个项目的全局设置](#多个项目的全局设置)
- [启用严格的编译检查](#启用严格的编译检查)

## 多个项目的全局设置

### 全局的项目设置

在项目根目录下创建 `Directory.Build.props` 文件，该文件中的配置作用解决方案中的所有项目。

```xml
<Project>
    <PropertyGroup>
        <TargetFramework>net5.0</TargetFramework>
        <LangVersion>latest</LangVersion>
        <Nullable>enable</Nullable>
        <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    </PropertyGroup>
</Project>
```

### 中央包版本控制

统一的依赖包版本管理有利于项目的维护升级，在项目编辑或 `Directory.Build.props` 中开启此项功能。

```xml
<Project>
    <ItemGroup>
        <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
    </ItemGroup>
</Project>
```

在项目目录下创建 `Directory.Packages.props` 文件，`PackageVersion` 指定引用的包以及版本号。

```xml
<Project>
    <ItemGroup>
        <PackageVersion Include="Newtonsoft.Json" Version="12.0.3" />
    </ItemGroup>
</Project>
```

在项目中引用依赖包使用 `PackageReference`。

```xml
<ItemGroup>
    <PackageReference Include="Newtonsoft.Json" />
</ItemGroup>
```

## 启用严格的编译检查

### 启用可为空的类型检查

设置所有类型都不可为 `null`，如果需要某个类型可以为 `null`，必须显式声明为可空类型，否则会编译警告。

在 `<PropertyGroup>` 下添加 `<Nullable>` 项目设置，`enable` 为启用，`disable` 为禁用。

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <Nullable>enable</Nullable>
    </PropertyGroup>
</Project>
```

启用可为空的类型检查后，所有的可空类型的声明必须添加 `?`:

```csharp
string notNull = "Hello";
string? nullable = null;
```

### 将警告视为错误

在项目编译中，将所有警告消息报告为错误。

在 `<PropertyGroup>` 下添加 `<TreatWarningsAsErrors>` 项目设置，`true` 为启用，`false` 为禁用。

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    </PropertyGroup>
</Project>
```
