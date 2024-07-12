namespace BuildWeek1.BusinessLayer
{
    /// <summary>
    /// Un servizio per la generazione di thumbnails.
    /// </summary>
    public interface IThumbnailService
    {

        /// <summary>
        /// Produce una thumbnail con tipo MIME "image/png" da un'immagine del database.
        /// </summary>
        /// <param name="originalContent">Chiave dell'immagine originale.</param>
        /// <param name="width">Larghezza desiderata.</param>
        /// <param name="height">Altezza desiderata.</param>
        /// <returns>La thumbnail nelle dimensioni richieste.</returns>
        byte[] Thumbnail(byte[] originalContent, int? width, int? height);
    }
}
