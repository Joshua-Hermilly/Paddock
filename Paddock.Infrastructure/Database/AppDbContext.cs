using Microsoft.EntityFrameworkCore;

namespace PaddockAPI.Infrastructure.Database;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Position>()
		.HasOne(p => p.Race)
		.WithMany()
		.HasForeignKey(p => p.RaceId)
		.OnDelete(DeleteBehavior.Restrict);

	}

	/*------------------------------------*/
	/* Tables                             */
	/*------------------------------------*/
	public DbSet<Constructor        > Constructors         { get; set; }
	public DbSet<Driver             > Drivers              { get; set; }
	public DbSet<Location           > Locations            { get; set; }
	public DbSet<PointByPosition    > PointByPositions     { get; set; }
	public DbSet<Position           > Positions            { get; set; }
	public DbSet<Race               > Races                { get; set; }
	public DbSet<Season             > Seasons              { get; set; }
	public DbSet<StandingConstructor> StandingConstructors { get; set; }
	public DbSet<StandingDriver     > StandingDrivers      { get; set; }
	public DbSet<Track              > Tracks               { get; set; }
}
