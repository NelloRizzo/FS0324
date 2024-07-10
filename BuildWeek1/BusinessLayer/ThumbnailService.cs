using BuildWeek1.BusinessLayer.Exceptions;
using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace BuildWeek1.BusinessLayer
{
    /// <summary>
    /// Implementazione del servizio attraverso la libreria ImageSharp.
    /// </summary>
    public class ThumbnailService : IThumbnailService
    {
        /// <summary>
        /// Contesto dati.
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Scala l'immagine.
        /// </summary>
        /// <param name="imageBytes">Immagine originale.</param>
        /// <param name="width">Larghezza desiderata.</param>
        /// <param name="height">Altezza desiderata.</param>
        /// <returns>La thumbnail dell'immagine alle dimensioni desiderate.</returns>
        private byte[] ScaleImage(byte[] imageBytes, int? width, int? height) {
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

        public ThumbnailService(DbContext context) {
            _context = context;
        }

        public byte[] Thumbnail(int imageId, int? width, int? height) {
            var image = _context.Images.Read(imageId) ?? throw new EntityNotFoundException { Id = imageId, EntityType = typeof(ImageEntity) };
            return ScaleImage(image.Content, width, height);
        }
    }
}
