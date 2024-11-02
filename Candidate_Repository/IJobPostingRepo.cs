using Candidate_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface IJobPostingRepo
    {
        public JobPosting GetJobPostingByID(string jobId);

        public List<JobPosting> GetJobPosting();
    }
}
