using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }

