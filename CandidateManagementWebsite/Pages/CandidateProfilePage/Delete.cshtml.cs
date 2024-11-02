using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagementWebsite.Data;
using Candidate_BussinessObject;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class DeleteModel : PageModel
    {
        private readonly CandidateManagementWebsite.Data.CandidateManagementWebsiteContext _context;

        public DeleteModel(CandidateManagementWebsite.Data.CandidateManagementWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CandidateProfile == null)
            {
                return NotFound();
            }

            var candidateprofile = await _context.CandidateProfile.FirstOrDefaultAsync(m => m.CandidateId == id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CandidateProfile == null)
            {
                return NotFound();
            }
            var candidateprofile = await _context.CandidateProfile.FindAsync(id);

            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _context.CandidateProfile.Remove(CandidateProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
