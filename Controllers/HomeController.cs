using Microsoft.AspNetCore.Mvc;

namespace TP06.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Partidos = BD.verInfoPartidos();

        return View();
    }

    public IActionResult AgregarForm(string partido)
    {

        if (partido == "Union")
        {
            ViewBag.partido = 3;
        } else {
            ViewBag.partido = 2;
        }
        return View();
    }

   public IActionResult agregarCandidatos(string nombre, string apellido, DateTime fecha, string foto, string postulacion, int IdPartido){
        Console.WriteLine(foto);
        BD.agregarCandidato(new Candidato(apellido,nombre, fecha ,foto, postulacion, IdPartido));
        return RedirectToAction("Index");
    }
    public IActionResult borrarCandidato(int IdCandidato){
        BD.borrarCandidato(IdCandidato);
        return RedirectToAction("Index");
    }

    public IActionResult Union(){
        List<Candidato> candidatos = BD.verCandidatos();
        List<Partido> partidos = BD.verInfoPartidos();
        ViewBag.Candidatos = candidatos;
        ViewBag.Partido = partidos;
        return View();
    }
    public IActionResult Juntos(){
        List<Candidato> candidatos = BD.verCandidatos();
        List<Partido> partidos = BD.verInfoPartidos();
        ViewBag.Candidatos = candidatos;
        ViewBag.Partido = partidos;
        return View();
    }

    public IActionResult detalleCandidato(int IdCandidato){
        ViewBag.id = IdCandidato;
        ViewBag.candidatos = BD.verCandidatos();
        return View();
    }
}
