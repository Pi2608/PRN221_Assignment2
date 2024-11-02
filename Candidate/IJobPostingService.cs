using Candidate_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface IJobPostingService
    {
        public JobPosting GetJobPostingById(string jobId);

        public List<JobPosting> GetJobPosting();
    }
}
