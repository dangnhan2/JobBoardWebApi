using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetSkill();
        Task AddSkill(SkillRequest category);
        Task UpdateSkill(Guid id, SkillRequest category);
        Task DeleteSkill(Guid id);
    }
}

