using ASPnet.Models;

namespace ASPnet.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> Get();
        public Beer? Get(int id);
    }
}
