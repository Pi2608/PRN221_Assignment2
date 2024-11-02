using Candidate_BussinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_LeDangPhucDat_RazorPage.Pages.Candidate_RazorPage
{
    public class LoginModel : PageModel
    {
        private readonly IHRAccountService accountService;

        public LoginModel(IHRAccountService accountServ)
        {
            accountService = accountServ;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            Hraccount? hraccount = accountService.GetHraccountByEmail(email);
            if (hraccount != null && hraccount.Password.Equals(password))
            {
                Response.Redirect("/Candidate_RazorPage/Index");
            }
            else
            {
                Response.Redirect("/LoginFail");
            }
        }
    }
}
