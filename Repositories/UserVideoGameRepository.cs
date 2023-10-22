using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
using GameStoreBeGNorbi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeGNorbi.Repositories
{
    public class UserVideoGameRepository : GenericRepository<UserVideoGame>, IRepository<UserVideoGame>
    {
        private readonly GameStoreContext _context;
        public UserVideoGameRepository(GameStoreContext context) : base(context) 
        {
            _context = context;
        }
        public override async Task Add(UserVideoGame data)
        {
            var userVideoGame = await _context.UserVideoGame
                .FindAsync(data.UserId, data.VideoGameId);
            if (userVideoGame != null) { return; }

            var user = await _context.Users
                .FindAsync(data.UserId);
            var game = await _context.VideoGames
                .FindAsync(data.VideoGameId);
            if (user == null || game == null) { return; }

            await _context.UserVideoGame
                .AddAsync(data);
            await _context
                .SaveChangesAsync();
        }
    }
}
