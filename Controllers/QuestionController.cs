using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Question.Data;
using QuestionFC.Models;

namespace QuestionFC.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionContext _context;

        public QuestionController(QuestionContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            return View(await _context.Question.ToListAsync());
        }





        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,QuestionText")] QuestionFC.Models.Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,QuestionText")] QuestionFC.Models.Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                // Remove related options
                var relatedOptions = _context.Option.Where(o => o.QuestionId == id);
                _context.Option.RemoveRange(relatedOptions);

                // Remove related responses
                var relatedResponses = _context.Reponse.Where(r => relatedOptions.Any(o => o.OptionId == r.OptionId));
                _context.Reponse.RemoveRange(relatedResponses);

                // Remove the question
                _context.Question.Remove(question);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }

        public IActionResult CreateQuestionAndOptions()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestionAndOptions(QuestionFC.Models.Question question, List<Option> options)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();

                foreach (var option in options)
                {
                    option.QuestionId = question.QuestionId;
                    _context.Add(option);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirect to the question list or another appropriate action
            }

            return View();
        }


        public IActionResult CreateResponse()
        {
            // Fetch questions and options to display in dropdowns
            ViewBag.Questions = _context.Question.ToList();
            ViewBag.Options = _context.Option.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResponse(Reponse response)
        {
            if (ModelState.IsValid)
            {
                _context.Add(response);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirect to the question list or another appropriate action
            }

            // Re-render the view with the ViewBag data
            ViewBag.Questions = _context.Question.ToList();
            ViewBag.Options = _context.Option.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResponseAndOptions(QuestionFC.Models.Question question, List<Option> options)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();

                foreach (var option in options)
                {
                    option.QuestionId = question.QuestionId;
                    _context.Add(option);
                }

                await _context.SaveChangesAsync();

                // Logique pour récupérer les résumés des réponses
                var summaries = new List<ReponseSummaryViewModel>();
                // Remplissez la liste summaries avec les données nécessaires
                // ...

                ViewBag.RespondentNames = // Logique pour obtenir les noms des répondants

                // Ajoutez les informations nécessaires à la ViewBag ou au modèle
                ViewBag.CreateResponseAndOptionsInfo = "Informations from CreateResponseAndOptions";

                return View("ViewResponsesSummary", summaries);
            }

            return View();
        }



        // GET: Question/ViewResponsesSummary
        [HttpGet]
    public IActionResult ViewResponsesSummary()
    {
        var summaries = new List<ReponseSummaryViewModel>();

        // Obtenez les résumés des réponses de votre base de données et remplissez la liste summaries

        return View(summaries);
    }

    [HttpGet]
    public IActionResult ViewOptionResponses(int optionId)
    {
        var option = _context.Option.Find(optionId);

        if (option == null)
        {
            return NotFound();
        }

        // Obtenez les réponses associées à l'option spécifiée

        var viewModel = new OptionResponsesViewModel
        {
            OptionText = option.OptionText,
            RespondentNames = option.Reponses.Select(r => r.RepondentName).ToList()
        };

        return View(viewModel);
    }
        





    }

    internal class OptionResponsesViewModel
    {
        public string OptionText { get; set; }
        public List<string> RespondentNames { get; set; }
    }

    internal class ReponseSummaryViewModel
    {
    }
}
