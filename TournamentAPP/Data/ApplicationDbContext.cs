using Microsoft.EntityFrameworkCore;
using TournamentAPP.Models;

namespace TournamentAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<PlayerStatistics> PlayerStatistics { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayerResults> GamePlayerResults { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<TournamentRound> TournamentRounds { get; set; }
        public DbSet<Rankings> Rankings { get; set; }

        private readonly string _connectionString;

        public ApplicationDbContext()
        {
            _connectionString = "Server=localhost\\SQL2022;Database=TournamentDB;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chaves primárias explícitas
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Tournament>().HasKey(t => t.Id);

            modelBuilder.Entity<PlayerStatistics>()
                 .Property(p => p.PlayerAvgPoints_PerGame)
                 .HasPrecision(5, 2);

            modelBuilder.Entity<PlayerStatistics>()
                .Property(p => p.PlayerAvgWins_PerGame)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.PlayerStatistics)
                .WithOne(s => s.Player)
                .HasForeignKey<PlayerStatistics>(s => s.Player_Id);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.User)
                .WithMany(u => u.Players)
                .HasForeignKey(p => p.User_Id);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Player)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(e => e.Player_Id);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Tournament)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(e => e.Tournament_Id);

            modelBuilder.Entity<GamePlayerResults>()
                .HasOne(r => r.Player)
                .WithMany(p => p.GamePlayerResults)
                .HasForeignKey(r => r.Player_Id);

            modelBuilder.Entity<GamePlayerResults>()
                .HasOne(r => r.Game)
                .WithMany(g => g.GamePlayerResults)
                .HasForeignKey(r => r.Game_Id);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Round)
                .WithMany()
                .HasForeignKey(g => g.Round_Id);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Tournament)
                .WithMany(t => t.Games)
                .HasForeignKey(g => g.Tournament_Id);
        }
    }
}


