using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObject;

namespace CandidateManagementWebsite.Data
{
    public class CandidateManagementWebsiteContext : DbContext
    {
        public CandidateManagementWebsiteContext (DbContextOptions<CandidateManagementWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate_BussinessObject.CandidateProfile> CandidateProfile { get; set; } = default!;
    }
}
