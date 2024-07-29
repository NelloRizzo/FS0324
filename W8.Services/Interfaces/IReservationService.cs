using W8.Services.Dto;

namespace W8.Services.Interfaces
{
    /// <summary>
    /// Servizi per la prenotazione.
    /// </summary>
    public interface IReservationService : ICrudService<ReservationDto>
    {
        /// <summary>
        /// Aggigunge un servizio addizionale.
        /// </summary>
        /// <param name="reservationId">Chiave per l'identificazione della prenotazione.</param>
        /// <param name="additionalService">Dati del servizio addizionale.</param>
        /// <exception cref="Exceptions.NotFoundException">Se non esiste la prenotazione.</exception>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task AddAdditionalServiceAsync(int reservationId, AdditionalServicePurchaseDto additionalService);
        /// <summary>
        /// Ottiene tutte le prenotazioni.
        /// </summary>
        /// <param name="from">Data di inizio.</param>
        /// <param name="to">Data di fine.</param>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<IEnumerable<ReservationDto>> GetAllAsync(DateOnly from, DateOnly to);
        /// <summary>
        /// Ottiene tutte le prenotazioni di un cliente.
        /// </summary>
        /// <param name="customerFiscalCode">Il codice fiscale del cliente.</param>
        /// <param name="from">Data di inizio.</param>
        /// <param name="to">Data di fine.</param>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<IEnumerable<ReservationDto>> GetAllAsync(string customerFiscalCode, DateOnly from, DateOnly to);
        /// <summary>
        /// Ottiene tutte le prenotazioni sulla base della tipologia.
        /// </summary>
        /// <param name="overnight">Tipologia di prenotazione.</param>
        /// <param name="from">Data di inizio.</param>
        /// <param name="to">Data di fine.</param>
        /// <exception cref="Exceptions.ServiceException">Se si verifica un problema durante l'esecuzione del metodo.</exception>
        Task<IEnumerable<ReservationDto>> GetAllAsync(OvernightType overnight, DateOnly from, DateOnly to);

    }
}
