using kino2.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kino2.controllers
{
    [Route("catalog")]
    public class CatalogController : Controller
    {
        

        FilmsContext db = new FilmsContext();
        public ViewResult Catalog()
        {
            
            return View(db.films);
        }
    }
}
