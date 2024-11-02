﻿using Candidate_BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;
        
        private static JobPostingDAO instance = null;

        public static JobPostingDAO Instance 
        { 
            get 
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            } 
        }
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public JobPosting GetJobPostingByID(string jobID)
        {
            return dbContext.JobPostings.SingleOrDefault(m => m.Equals(jobID));
        }

        public List<JobPosting> GetJobPosting()
        {
            return dbContext.JobPostings.ToList();
        }
    }
}
