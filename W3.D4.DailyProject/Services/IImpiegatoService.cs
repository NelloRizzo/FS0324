using W3.D4.DailyProject.Models;

namespace W3.D4.DailyProject.Services
{
    public interface IImpiegatoService
    {
        void AssumiImpiegato(Impiegato impiegato, Impiego impiego);
        void CambiaImpiego(int impiegatoId, Impiego impiego);

        IEnumerable<Impiegato> GetAll(decimal reddito);
    }
}
