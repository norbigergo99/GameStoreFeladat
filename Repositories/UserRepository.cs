using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
using GameStoreBeGNorbi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeGNorbi.Repositories
{
    public class UserRepository : GenericRepository<User>, IRepository<User>
    {
        private readonly GameStoreContext _context;
        public UserRepository(GameStoreContext context) : base(context) 
        {
            _context = context;
        }
        public override async Task<List<User>> GetAll() => 
            await _context.Users
            .Include(a => a.VideoGames)
            .ToListAsync();
        public override async Task<User?> GetById(int id) => 
            await _context.Users
            .Include(a => a.VideoGames)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }
}
