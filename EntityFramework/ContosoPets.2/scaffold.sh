dotnet ef dbcontext scaffold "Host=localhost;Database=contoso_pets;Integrated Security=True;Username=postgres;Password=root" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -c ContosoPetsContext -d
