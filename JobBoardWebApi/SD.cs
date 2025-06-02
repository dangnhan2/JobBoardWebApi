namespace JobBoardWebApi
{
    public static class SD
    {
        public static  string Candidate = "Candidate";
        public static  string Admin = "Admin";
        public static string Recruiter = "Recruiter";

        public static IQueryable<T> Paged<T>(this IQueryable<T> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        //public async Task<T> CheckIsExits(this )
    }
}
