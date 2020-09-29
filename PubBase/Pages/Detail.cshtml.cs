using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PubBase.Models;

namespace PubBase.Pages
{
    public class DetailModel : PageModel
    {
        AppDbContext _db { get; set; }
        public List<Pub> Pubs { get; set; }
        public Pub Pub { get; set; }
        public DetailModel( AppDbContext db)
        {
            _db = db;
        }
        public ActionResult OnGet(int? id = null)
        {

            Pub = _db.Pubs.SingleOrDefault(p => p.Id == id);  
            if(Pub == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}