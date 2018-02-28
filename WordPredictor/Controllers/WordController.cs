using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordPredictor.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordPredictor.Controllers
{
    public class WordController : Controller
    {
        // GET: /<controller>/

        private readonly WordContext _context;
        public WordController(WordContext context)
        {
            _context = context;    
        }

        public IActionResult Index()
        {
          return View("Index");
        }

        public string OnTextChange(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var words = from w in _context.Words
                        where w.Code.Equals(text)
                        orderby w.Phrase ascending
                        select w;
                                         

            if (0 == words.Count())
            {
                return "No word matched the phrase";
            }
            else
            {
                return string.Join(',', words.Select(w => w.Phrase));     
            }

        }
    }
}
