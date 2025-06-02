using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public class UserRepo : IUserRepo
    {   
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context) {
          _context = context;
        }
        public async Task<User?> GetById(string id)
        {
           return await _context.Users
                .Include(x => x.Candidate)
                .Include(x => x.Recruiter)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
