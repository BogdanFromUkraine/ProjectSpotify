using ProjectTrackingSpotify.DataAccess.Data;
using ProjectTrackingSpotify.DataAccess.Repository.IRepository;
using ProjectTrackingSpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess.Repository;

namespace ProjectTrackingSpotify.DataAccess.Repository
{
    public class UrlSpotifyRepository : Repository<UrlSpotify>, IUrlSpotifyRepository
    {
        private ApplicationDbContext _db;
        public UrlSpotifyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Save()
        {
            _db.SaveChanges();
        }

        public async Task Update(UrlSpotify urlSpotify)
        {
            _db.UrlSpotify.Update(urlSpotify);   
        }
    }
}
