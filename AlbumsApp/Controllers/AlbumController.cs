using AlbumsApp.Entities;
using AlbumsApp.Models;
using AlbumsApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AlbumsApp.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumManager _albumManager; // creating private interface varibale.
        public AlbumController(IAlbumManager albumManager) //Injecting Interface type of IAlbumManger.
        { 
            _albumManager = albumManager; // 
        }

        [Route("List/{genre?}")]
        public IActionResult List(String genre)
        {
            //List<Album> albums;
            ICollection<Album> albums;

            if (string.IsNullOrEmpty(genre) || genre == "All")
            {
                albums = _albumManager.GetAlbums();
                genre = "All";
            }
            else
            {
                albums = _albumManager.GetAlbumByGenre(genre).ToList();
            }

            AlbumViewModel albumViewModel = new AlbumViewModel()
            {
                Genres = _albumManager.GetAllGenres(),
                RandomAlbum = _albumManager.GetRandomAlbum(),
                ActiveGenre = genre,
                Albums = albums
            };
            return View(albumViewModel);
        }
    }
}
