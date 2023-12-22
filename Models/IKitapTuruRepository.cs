using System.Linq.Expressions;
using WebUygulamaProje1.Controllers;
using WebUygulamaProje1.Entity;

namespace WebUygulamaProje1.Models
{
    public interface IKitapTuruRepository : IRepository<KitapTuru>
    {      
        void Guncelle(KitapTuru kitapTuru);
        void Kaydet();   
    }
}
