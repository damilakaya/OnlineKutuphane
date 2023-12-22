
using WebUygulamaProje1.Entity;
using WebUygulamaProje1.Utility;
using static NuGet.Packaging.PackagingConstants;

namespace WebUygulamaProje1.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public KitapRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }

        public void Guncelle(Kitap kitap)
        {
            _uygulamaDbContext.Update(kitap);
        }
    }
}
