# 添加新的迁移遇到无法创建 DbContext 对象的问题

```shell
> dotnet ef migrations add DbInit
Build started...
Build succeeded.
Unable to create an object of type 'UserIdentityDbContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
```

在启动项目安装工具

```shell
Install-Package Microsoft.EntityFrameworkCore.Design
```

如果你没有指定迁移程序集，默认与 DbContext 为同一个程序集。通常指定了迁移程序集会在 `AddDbContext` 中加上 `MigrationsAssembly` 方法的调用，例如下面的代码

```csharp
services.AddDbContext<TUserIdentityDbContext>(options => 
    options.UseNpgsql(userIdentityDbConnection, sql => sql.MigrationsAssembly(migrationsAssembly)));
```

然后在迁移程序集的目录下执行迁移命令

```shell
dotnet ef --startup-project ..\PowerAdmin migrations add DbInit
```
