# MyAdmin_Core8

### 1st Shared_ClassLibrary dependency
* default

### 2nd Project Server_WebAPI dependency
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Shared_ClassLibrary

NuGet administrator console
```
Scaffold-DbContext "Data Source=server_name; Initial Catalog=database_name; User ID=db_user; Password=db_password; MultipleActiveResultSets=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models
```
> :warning: make sure to remove connection string from DBContext class and add to appsettings.Development.json file

obs: server_name == (localhost) or server_name\Sql_instance

### 3rd Project Client_BlazorWebAssembly dependency
* Shared_ClassLibrary


