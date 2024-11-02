using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BussinessObject;
using Candidate_DAO;
using Candidate_Service;

namespace CandidateManagement_LeDangPhucDat_RazorPage.Pages.Candidate_RazorPage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService postingService;

        public CreateModel(ICandidateProfileService profileServ, IJobPostingService jobPostingServ)
        {
            profileService = profileServ;
            postingService = jobPostingServ;
        }

        public void OnGet()
        {
            ViewData["PostingId"] = postingService.GetJobPosting()
        .Select(jp => new SelectListItem
        {
            Value = jp.PostingId.ToString(),
            Text = jp.JobPostingTitle
        }).ToList();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public void OnPost()
        {

            profileService.AddCandidateProfile(CandidateProfile);

            Response.Redirect("./Index");
        }
    }
}
