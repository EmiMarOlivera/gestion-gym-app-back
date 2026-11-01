using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext: DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){

    }
}


