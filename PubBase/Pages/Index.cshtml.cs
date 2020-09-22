using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PubBase.Models;

namespace PubBase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        AppDbContext _db { get; set; }
        public List<Pub> Pubs { get; set; }
        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            Pubs = _db.Pubs.ToList();
        }
        /*
         * _db.Pubs.Add(New Pub{bez id!, name, muni});
         * _db.SaveChanges();
         */
    }
}
