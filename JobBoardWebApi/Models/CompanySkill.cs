namespace JobBoardWebApi.Models
{
    public class CompanySkill
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
