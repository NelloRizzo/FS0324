using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace BuildWeek1.BusinessLayer.V1
{
    /// <summary>
    /// Implementazione del servizio attraverso la libreria ImageSharp.
    /// </summary>
    public class ThumbnailService : IThumbnailService
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger<ThumbnailService> _logger;

        /// <summary>
        /// Scala l'immagine.
        /// </summary>
        /// <param name="imageBytes">Immagine originale.</param>
        /// <param name="width">Larghezza desiderata.</param>
        /// <param name="height">Altezza desiderata.</param>
        /// <returns>La thumbnail dell'immagine alle dimensioni desiderate.</returns>
        private static byte[] ScaleImage(byte[] imageBytes, int? width, int? height) {
            Image image = Image.Load(imageBytes);
            lock (image) {
                int newWidth = image.Width;
                int newHeight = image.Height;

                if (width.HasValue) {
                    var r = 1.0 * width.Value / image.Width;
                    newWidth = width.Value;
                    newHeight = (int)(image.Height * r);
                }
                if (height.HasValue) {
                    var r = 1.0 * height.Value / image.Height;
                    newHeight = height.Value;
                    newWidth = (int)(image.Width * r);
                }

                image.Mutate(x => x.Resize(newWidth, newHeight));

                using var ms = new MemoryStream();
                image.Save(ms, new PngEncoder());
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <remarks>Questo costruttore ha il solo compito di ottenere il datacontext e il logger service
        /// dalla D.I. e passarli alla classe base per averli a disposizione da essa.</remarks>
        public ThumbnailService(ILogger<ThumbnailService> logger) {
            _logger = logger;
        }

        public byte[] Thumbnail(byte[] content, int? width, int? height) {
            return ScaleImage(content, width, height);
        }
    }
}
