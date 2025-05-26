using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetSkill();
        Task AddSkill(SkillAction category);
        Task UpdateSkill(Guid id, SkillAction category);
        Task DeleteSkill(Guid id);
    }
}

