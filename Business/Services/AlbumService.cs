using Business.Models;
using DataAccess.Contexts;

namespace Business.Services
{
    public interface IAlbumService
    {
        IQueryable<AlbumModel> Query();
    }

    public class AlbumService : IAlbumService
    {
        private readonly Db _db;

        public AlbumService(Db db)
        {
            _db = db;
        }

        public IQueryable<AlbumModel> Query()
        {
            return _db.Albums.OrderBy(a => a.Name).Select(a => new AlbumModel()
            {
                Id = a.Id,
                Name = a.Name
            });
        }
    }
}
