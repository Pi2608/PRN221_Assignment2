using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObject;
using Candidate_DAO;
using Candidate_Service;

namespace CandidateManagement_LeDangPhucDat_RazorPage.Pages.Candidate_RazorPage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobPostingService;

        public EditModel(ICandidateProfileService profileServ, IJobPostingService jobPostingServ)
        {
            profileService = profileServ;
            jobPostingService = jobPostingServ;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = profileService.GetCandidateProfileByID(id);

            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = jobPostingService.GetJobPosting()
         .Select(jp => new SelectListItem
         {
             Value = jp.PostingId.ToString(),
             Text = jp.JobPostingTitle
         }).ToList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public void OnPost(string id)
        {
            profileService.UpdateCandidateProfile(id, CandidateProfile);
            Response.Redirect("./Index");
        }
    }
}
