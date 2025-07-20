using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoginForm.Models;

namespace LoginForm.Views.Home
{
    public class LoginModel : PageModel
    {
        private readonly LoginForm.Models.UserDbContext _context;

        public LoginModel(LoginForm.Models.UserDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UseTbls UseTbls { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(UseTbls);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
