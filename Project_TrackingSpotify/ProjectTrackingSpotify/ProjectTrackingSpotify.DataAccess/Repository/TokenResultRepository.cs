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
    public class TokenResultRepository : Repository<TokenResult>, ITokenResultRepository
    {
        private ApplicationDbContext _db;
        public TokenResultRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Save()
        {
            _db.SaveChanges();
        }

        public async Task Update(TokenResult tokenResult)
        {
            _db.TokenResults.Update(tokenResult);   
        }
    }
}
