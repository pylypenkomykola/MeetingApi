using MeetingApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace MeetingApi.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> opt): base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMeeting>().HasKey(um => new { idUser = um.IdUser, idMeeting = um.IdMeeting });

            modelBuilder.Entity<User>()
                .Property(user => user.IdUser)
                .UseIdentityAlwaysColumn()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Meeting>()
                .Property(meeting => meeting.IdMeeting)
                .UseIdentityAlwaysColumn()
                .ValueGeneratedOnAdd();
        }
        
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<UserMeeting> UsersMeetings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
