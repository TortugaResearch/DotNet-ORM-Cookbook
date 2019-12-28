To regenerate the EF Models, use this command from the Package Console.

```
Scaffold-DbContext "Server=.;Database=OrmCookbook;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -DataAnnotations
```
