using CretaceousClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CretaceousClient.Controllers
{
  public class AnimalsController : Controller
  {
    // GET /animals
    public async Task<IActionResult> Index()
    {
      List<Animal> allAnimals = await Animal.GetAnimals();
      return View(allAnimals);
    }

    public async Task<IActionResult> Details(int id)
    {
      Animal animal = await Animal.GetDetails(id);
      return View(animal);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await Animal.Delete(id);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      Animal animal = await Animal.GetDetails(id);
      return View(animal);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Animal animal)
    {
      await Animal.Put(animal);
      return RedirectToAction("Details",new{id = animal.AnimalId});
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Animal animal)
    {
      await Animal.Post(animal);
      return RedirectToAction("Index");
    }
  }
}