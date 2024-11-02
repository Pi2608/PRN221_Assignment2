using Candidate_BussinessObject;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepo : ICandidateProfifeRepo
    {
        public CandidateProfile GetCandidateProfileByID(string id)=>CandidateProfileDAO.Instance.GetCandidateProfileByID(id);
        
        public List<CandidateProfile> GetCandidateProfiles()=>CandidateProfileDAO.Instance.GetCandidateProfiles();
        
        public bool AddCandidateProfile(CandidateProfile candidateProfile)=>CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string profileID)=>CandidateProfileDAO.Instance.DeleteCandidateProfile(profileID);

        public bool UpdateCandidateProfile(string profileID, CandidateProfile candidateProfile)=>CandidateProfileDAO.Instance.UpdateCandidateProfile(profileID, candidateProfile);

        public List<CandidateProfile> SearchCandidates(string? fullname, DateTime? birthday)=>CandidateProfileDAO.Instance.SearchCandidates(fullname, birthday);
    }
}
