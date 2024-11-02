using Candidate_BussinessObject;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfifeRepo profileRepo;

        public CandidateProfileService()
        {
            profileRepo = new CandidateProfileRepo();
        }
        public CandidateProfile GetCandidateProfileByID(string id)
        {
            return profileRepo.GetCandidateProfileByID(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return profileRepo.GetCandidateProfiles();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(string profileID)
        {
            return profileRepo.DeleteCandidateProfile(profileID); 
        }

        public bool UpdateCandidateProfile(string profileID, CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProfile(profileID, candidateProfile);
        }

        public List<CandidateProfile> SearchCandidates(string? fullname, DateTime? birthday)
        {
            return profileRepo.SearchCandidates(fullname, birthday);
        }
    }
}
