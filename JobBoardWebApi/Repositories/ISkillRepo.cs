using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Repositories
{
    public interface ISkillRepo
    {
        Task<IEnumerable<SkillDto>> GetSkill();
        Task AddSkill(SkillRequest category);
        Task UpdateSkill(Guid id, SkillRequest category);
        Task DeleteSkill(Guid id);
    }
}
