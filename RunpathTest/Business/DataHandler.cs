using Business.Core;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class DataHandler : IDataHandler
    {
        private readonly HttpHandler<Photo> httpPhotoHandler;
        private readonly HttpHandler<Album> httpAlbumHandler;
        private const string AlbumEndPoint = "http://jsonplaceholder.typicode.com/albums";
        private const string PhotoEndPoint = "http://jsonplaceholder.typicode.com/photos";

        IEnumerable<Album> albums = null;
        IEnumerable<Photo> photos = null;

        public DataHandler(HttpHandler<Photo> httpPhotoHandler, HttpHandler<Album> httpAlbumHandler)
        {
            this.httpPhotoHandler = httpPhotoHandler ?? throw new ArgumentNullException(nameof(httpPhotoHandler));
            this.httpAlbumHandler = httpAlbumHandler ?? throw new ArgumentNullException(nameof(httpAlbumHandler));
        }

        public async Task<IEnumerable<DataTableModel>> GetDataTableAsync()
        {
            await Task.Factory.StartNew(async () =>
            {
                albums = await httpAlbumHandler.GetResultsAsync(AlbumEndPoint);
                photos = await httpPhotoHandler.GetResultsAsync(PhotoEndPoint);
            }).GetAwaiter().GetResult();

            var result = albums.SelectMany(a => photos.Where(p => p.AlbumId == a.Id).Select(v => new DataTableModel()
            {
                AlbumName = a.Title,
                PhotoTitle = v.Title,
                Thumbnail = v.ThumbnailUrl,
                Url = v.Url
            }));

            return result;
        }
    }
}
