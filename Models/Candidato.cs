public class Candidato
{
    public Candidato(string Apellido, string Nombre, string Foto, string Postulacion, int IdPartido){
        this.Apellido = Apellido;
        this.Nombre = Nombre;
        this.Foto = Foto;
        this.Postulacion = Postulacion;
        this.IdPartido = IdPartido;

    }

    public Candidato(){
        
    }

    public int IdCandidato {get; set;}    
    public int IdPartido {get; set;}    
    public string Apellido {get; set;}
    public string Nombre {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public string Foto {get; set;}
    public string Postulacion {get; set;}
}