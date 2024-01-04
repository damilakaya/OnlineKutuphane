using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebUygulamaProje1.Entity;
using WebUygulamaProje1.Models;

// veri tabanında EF tablo oluşturması için ilgili model sınıfları buraya eklenmeli

namespace WebUygulamaProje1.Utility
{
    public class UygulamaDbContext : IdentityDbContext

    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) :  base(options) { }

        public DbSet<KitapTuru> KitapTurleri { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<Kiralama> Kiralamalar { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        

      


    }
}
