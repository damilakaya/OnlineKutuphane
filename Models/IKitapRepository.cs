using WebUygulamaProje1.Entity;

namespace WebUygulamaProje1.Models
{
    public interface IKitapRepository : IRepository<Kitap>
    {        
        void Kaydet();
    
    }
}
