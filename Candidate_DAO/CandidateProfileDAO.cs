using Candidate_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfile GetCandidateProfileByID(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfiles() 
        {
            return context.CandidateProfiles.ToList();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile) 
        {
            bool isSuccess = false;
            CandidateProfile candidate = this.GetCandidateProfileByID(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }
        public bool DeleteCandidateProfile(string profileID)
        {
            bool isSuccess = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileByID(profileID);
            try
            {
                if (candidateProfile != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }
        public bool UpdateCandidateProfile(string profileID, CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            try
            {
                CandidateProfile updatedCandidate = this.GetCandidateProfileByID(profileID);
                if (candidateProfile != null)
                {
                    updatedCandidate.Fullname = candidateProfile.Fullname;
                    updatedCandidate.ProfileUrl = candidateProfile.ProfileUrl;
                    updatedCandidate.Birthday = updatedCandidate.Birthday;
                    updatedCandidate.PostingId = updatedCandidate.PostingId;
                    updatedCandidate.ProfileShortDescription = updatedCandidate.ProfileShortDescription;
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isSuccess;
        }

        public List<CandidateProfile> SearchCandidates(string? fullname, DateTime? birthday)
        {
            var query = context.CandidateProfiles.AsQueryable();

            if (!string.IsNullOrEmpty(fullname))
            {
                query = query.Where(c => c.Fullname.Contains(fullname));
            }

            if (birthday.HasValue)
            {
                query = query.Where(c => c.Birthday == birthday.Value);
            }

            return query.ToList();
        }
    }
}
