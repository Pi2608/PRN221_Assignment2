﻿using Candidate_BussinessObject;
using Candidate_DAO;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo iAccountRepo;

        public HRAccountService()
        {
            iAccountRepo = new HRAccountRepo();
        }

        public List<Hraccount> GetHraccount() 
        {
            return iAccountRepo.GetHraccounts();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }
    }
}
