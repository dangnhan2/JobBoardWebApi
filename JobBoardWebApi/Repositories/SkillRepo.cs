
using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ApplicationDbContext _context;

        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSkill(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public void DeleteSkill(Skill skill)
        {
            _context.Skills.Remove(skill);
        }

        public async Task<Skill?> GetById(Guid id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public IQueryable<Skill> GetSkills()
        {
           return _context.Skills.AsQueryable();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
        }

    }
}

