using Microsoft.EntityFrameworkCore;

namespace CandidateManagement_LeDangPhucDat_RazorPage.Data
{
    public class CandidateManagement_LeDangPhucDat_RazorPageContext : DbContext
    {
        public CandidateManagement_LeDangPhucDat_RazorPageContext(DbContextOptions<CandidateManagement_LeDangPhucDat_RazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate_BussinessObject.CandidateProfile> CandidateProfile { get; set; } = default!;
    }
}
