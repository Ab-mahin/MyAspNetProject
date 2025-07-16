using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspCRUD.Views.Home
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeDbContext _context;

        public DetailsModel(EmployeeDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
