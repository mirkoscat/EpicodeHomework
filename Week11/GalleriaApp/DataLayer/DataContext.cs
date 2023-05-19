
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class DataContext:DbContext
	{  public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<Vote> Votes { get; set; }
		public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
	}
}
