using AlbumsApp.Entities;

namespace AlbumsApp.Services
{
    public interface IAlbumManager
    {
        //AddAlbum, GetAllAlbums, GetAlbumsByGenre, GetRandomAlbum, and GetAllGenres

        public void AddAlbum(Album album);

        public ICollection<Album> GetAlbums();

        public ICollection<Album> GetAlbumByGenre(string genre);

        public Album GetRandomAlbum();

        public ICollection<String> GetAllGenres();
    }
}
