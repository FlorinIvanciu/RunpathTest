using Business.Core;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class DataHandler : IDataHandler
    {
        private readonly IHttpHandler<Photo> httpPhotoHandler;
        private readonly IHttpHandler<Album> httpAlbumHandler;

        private IEnumerable<Album> albums = null;
        private IEnumerable<Photo> photos = null;

        public DataHandler(IHttpHandler<Photo> httpPhotoHandler, IHttpHandler<Album> httpAlbumHandler)
        {
            this.httpPhotoHandler = httpPhotoHandler ?? throw new ArgumentNullException(nameof(httpPhotoHandler));
            this.httpAlbumHandler = httpAlbumHandler ?? throw new ArgumentNullException(nameof(httpAlbumHandler));
        }

        public async Task<IEnumerable<DataTableModel>> GetDataTableAsync()
        {
            await Task.Factory.StartNew(async () =>
            {
                albums = await httpAlbumHandler.GetResultsAsync();
                photos = await httpPhotoHandler.GetResultsAsync();
            }).GetAwaiter().GetResult();

            return albums.SelectMany(a => photos.Where(p => p.AlbumId == a.Id).Select(v => new DataTableModel()
            {
                AlbumName = a.Title,
                PhotoTitle = v.Title,
                Thumbnail = v.ThumbnailUrl,
                Url = v.Url
            }));
        }
    }
}
