using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagementWebsite.Data;
using Candidate_BussinessObject;
using Candidate_Service;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _service;

        public CreateModel(ICandidateProfileService context, IJobPostingService jobService)
        {
            _service = ;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CandidateProfile != null)
            {
                CandidateProfile = await _context.CandidateProfile
                .Include(c => c.Posting).ToListAsync();
            }
        }
    }
}
