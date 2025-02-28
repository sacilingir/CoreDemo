using Entitiy.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        //bağlantı stringi tanımlayacağız.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=PC\\SQLEXPRESS;database=CoreBlogDb;integrated security = true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam) // Match tablosunda bir HomeTeam vardır (bire çok ilişki).
                .WithMany(y => y.HomeMatches) // HomeTeam birçok HomeMatches içerebilir.
                .HasForeignKey(z => z.HomeTeamID) // Match tablosunda HomeTeamID, yabancı anahtar olarak tanımlanır.
                .OnDelete(DeleteBehavior.ClientSetNull);  // Eğer takım silinirse, ilgili maçlardaki HomeTeamID null olur.


            modelBuilder.Entity<Match>()
                .HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
            .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

      //bire cok iliski oldugu icin HasOne(bir) -WithMany(cok)
      //HasOne da Writer olmasi gerek cunki bir yazar birden cok mesaj gonderebilir, WithMany se mesajlarla bagli.
      //Writer icerisinde virtual ile belirtdigimiz WriterSender ve WriterReceiver aslinda Mesajlari gosteriyor.Bu yuzden adlandirmayi MessageSender ve MessageReceiver yaparsak karistirmadan ilerletebiliriz. 
       //Ayni seyi Mesajlarda da yapmaliyiz, Mesajlarda Writer dan turetdigimizleri SenderUser ve SenderReceiver aslinda Writeri gosteriyor bu yuzden adlandirmada SenderWriter ve ReceiverWriter yaparsak,
        //HasOne - WithMany iliskisini kurarken HasOne kisminda Writer olanlari (yani WriterSender ve WriterReceiver) yazicaz, WithMany deyse Message olanlari(yani MessageSender ve MessageReceiver) yazicaz.
         //Bide HasForeignKey ler vardi, Bunlarinda Sonlarina ID yazmamiz yeterli olur, SenderID ve ReceiverID.Boylece HasOne - Bir, WithMany-Cok, HasForeignKey- ID ile akilda kalir

            // HomeMatches => WriterSender
            //AwayMatches => WriterReceiver

        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message2> Message2s { get; set; }
    }
}
