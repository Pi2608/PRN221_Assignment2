using Candidate_BussinessObject;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface ICandidateProfileService
    {
        public CandidateProfile GetCandidateProfileByID(string id);
        public List<CandidateProfile> GetCandidateProfiles();
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        public bool DeleteCandidateProfile(string profileID);
        public bool UpdateCandidateProfile(string profileID, CandidateProfile candidateProfile);
        public List<CandidateProfile> SearchCandidates(string? fullname, DateTime? birthday);
    }
}
