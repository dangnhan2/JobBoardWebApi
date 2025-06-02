using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface IUserRepo
    {
        public Task<User?> GetById(string id);
    }
}
