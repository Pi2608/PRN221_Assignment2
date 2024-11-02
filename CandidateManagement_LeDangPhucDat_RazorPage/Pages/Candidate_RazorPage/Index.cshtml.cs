using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObject;
using Candidate_DAO;
using Candidate_Service;

namespace CandidateManagement_LeDangPhucDat_RazorPage.Pages.Candidate_RazorPage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService profileServive;

        public IndexModel(ICandidateProfileService profileServ)
        {
            profileServive = profileServ;
        }

        public List<CandidateProfile> CandidateProfile { get; set; } = default!;

        public void OnGet()
        {
            CandidateProfile = profileServive.GetCandidateProfiles();
        }

        public void OnPost()
        {
            string fullname = Request.Form["fullname"];
            DateTime? birthday = string.IsNullOrEmpty(Request.Form["birthday"])
                ? (DateTime?)null
                : DateTime.Parse(Request.Form["birthday"]);

            CandidateProfile = profileServive.SearchCandidates(fullname, birthday);
        }
    }
}
