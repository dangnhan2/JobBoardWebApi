using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface ISkillRepo
    {
        IQueryable<Skill> GetSkills();
        Task<Skill?> GetById (Guid id);
        Task AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(Skill skill);
        Task Save();
    }
}
