using Candidate_BussinessObject;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;

        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }
        
        public List<JobPosting> GetJobPosting()
        {
            return jobPostingRepo.GetJobPosting();
        }

        public JobPosting GetJobPostingById(string jobId)
        {
            return jobPostingRepo.GetJobPostingByID(jobId);
        }

    }
}
