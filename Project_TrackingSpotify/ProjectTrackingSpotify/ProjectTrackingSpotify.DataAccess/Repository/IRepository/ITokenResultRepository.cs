using ProjectTrackingSpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess.Repository.IRepository;

namespace ProjectTrackingSpotify.DataAccess.Repository.IRepository
{
    public interface ITokenResultRepository : IRepository<TokenResult>
    {
        //ці два методи асинхронні
        Task Update(TokenResult tokenResult);
        Task Save();
    }
}
