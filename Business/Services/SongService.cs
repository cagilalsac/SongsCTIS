using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface ISongService
    {
        IQueryable<SongModel> Query();
        bool Add(SongModel model);
        bool Update(SongModel model);
        bool Delete(int id);
    }

    public class SongService : ISongService
    {
        private readonly Db _db;

        public SongService(Db db)
        {
            _db = db;
        }

        public bool Add(SongModel model)
        {
            if (_db.Songs.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim()))
                return false;
            Song entity = new Song()
            {
                AlbumId = model.AlbumId ?? 0,
                Name = model.Name.Trim(),
                Rating = model.Rating,
                Year = model.Year
            };
            _db.Songs.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Song entity = _db.Songs.SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return false;
            _db.Songs.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public IQueryable<SongModel> Query()
        {
            return _db.Songs.Include(s => s.Album)
                .OrderByDescending(s => s.Year).ThenByDescending(s => s.Rating).ThenBy(s => s.Name)
                .Select(s => new SongModel()
                {
                    AlbumId = s.AlbumId,
                    AlbumOutput = s.Album.Name,
                    Id = s.Id,
                    Name = s.Name,
                    Rating = s.Rating,
                    Year = s.Year
                });
        }

        public bool Update(SongModel model)
        {
            if (_db.Songs.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim() && s.Id != model.Id))
                return false;
            Song existingEntity = _db.Songs.SingleOrDefault(s => s.Id == model.Id);
            if (existingEntity is null)
                return false;
            existingEntity.AlbumId = model.AlbumId ?? 0;
            existingEntity.Name = model.Name.Trim();
            existingEntity.Rating = model.Rating;
            existingEntity.Year = model.Year;
            _db.Songs.Update(existingEntity);
            _db.SaveChanges();
            return true;
        }
    }
}
