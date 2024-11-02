using Candidate_BussinessObject;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPosting() => JobPostingDAO.Instance.GetJobPosting();

        public JobPosting GetJobPostingByID(string jobId) => JobPostingDAO.Instance.GetJobPostingByID(jobId);
    }
}
