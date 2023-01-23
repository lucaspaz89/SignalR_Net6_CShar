using Microsoft.EntityFrameworkCore;
using SignalR_Cshar_DB.Models;

namespace SignalR_Cshar_DB.DB;

public partial class LpProductDB : DbContext
{
	public LpProductDB(DbContextOptions<LpProductDB> options) : base(options){ }

	public virtual DbSet<MProducts> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<MProducts>(enty => { enty.HasNoKey(); });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
