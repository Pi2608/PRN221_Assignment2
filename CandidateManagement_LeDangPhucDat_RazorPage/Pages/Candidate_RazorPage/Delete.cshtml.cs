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
    public class DeleteModel : PageModel
    {
        private readonly ICandidateProfileService profileService;

        public DeleteModel(ICandidateProfileService profileServ)
        {
            profileService = profileServ;
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
            else
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public void OnPost(string id)
        {
            var candidateprofile = profileService.GetCandidateProfileByID(id);
            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                profileService.DeleteCandidateProfile(id);
            }

            Response.Redirect("./Index");
        }
    }
}
