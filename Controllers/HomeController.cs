using Microsoft.AspNetCore.Mvc;

namespace TP06.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Partidos = BD.verInfoPartidos();

        return View();
    }

    public IActionResult AgregarForm()
    {
        return View();
    }

   public IActionResult agregarCandidatos(string nombre, string apellido, DateTime fecha, string foto, string postulacion, int IdPartido){
        BD.agregarCandidato(new Candidato(apellido,nombre ,foto, postulacion, IdPartido));
        return RedirectToAction("Index");
    }
    public IActionResult borrarCandidato(){

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
}
