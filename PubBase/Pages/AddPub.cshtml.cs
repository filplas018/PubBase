using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PubBase.Models;

namespace PubBase.Pages
{
    public class AddPubModel : PageModel
    {
        AppDbContext _db { get; set; }
        public List<Pub> Pubs { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Muni { get; set; }
        public AddPubModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            _db.Pubs.Add(new Pub { Name = Name, Municipality = Muni });
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}