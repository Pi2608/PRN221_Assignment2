using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagementWebsite.Data;
using Candidate_BussinessObject;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly CandidateManagementWebsite.Data.CandidateManagementWebsiteContext _context;

        public CreateModel(CandidateManagementWebsite.Data.CandidateManagementWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_context.Set<JobPosting>(), "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CandidateProfile == null || CandidateProfile == null)
            {
                return Page();
            }

            _context.CandidateProfile.Add(CandidateProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
