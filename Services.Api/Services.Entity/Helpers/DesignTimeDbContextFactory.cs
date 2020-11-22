// using System.IO;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using Services.Entity.Contexts;

// namespace Services.Entity.Helpers
// {
// public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppContexto> 
// { 
//    public AppContexto CreateDbContext(string[] args) 
//    { 
//       IConfigurationBuilder configuration = new ConfigurationBuilder();
//       var ruta = Path.Combine(Directory.GetCurrentDirectory() , "appsettings.json");
//       configuration.AddJsonFile(ruta, false);
            
//       var root = configuration.Build(); 
//       var builder = new DbContextOptionsBuilder<AppContexto>(); 
//       var connectionString = root["BDConexion"]; 


// System.Diagnostics.Debug.WriteLine(connectionString);
//       builder.UseSqlServer(connectionString); 
//       return new AppContexto(builder.Options); 
//    } 
// }
// }