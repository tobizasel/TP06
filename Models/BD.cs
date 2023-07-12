using System.Data.SqlClient;
using Dapper;


class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=true;";

     static public List<Partido> verInfoPartidos(){

        List<Partido> Partidos = null;


        using (SqlConnection BD = new SqlConnection(_connectionString)){
            string query = "SELECT * from Partido";
            Partidos = BD.Query<Partido>(query).ToList();
            foreach (Partido item in Partidos)
            {
                Console.WriteLine(item);
            }
            return Partidos;
        }
    }

    static public List<Candidato> verCandidatos(){
        
        List<Candidato> candidatos = null;

        using (SqlConnection BD = new SqlConnection(_connectionString)){
            string query = "SELECT * from Candidato";
            candidatos = BD.Query<Candidato>(query).ToList();
            foreach (Candidato item in candidatos)
            {
                Console.WriteLine(item);
            }
            return candidatos;
        }
    }

    public static void agregarCandidato(Candidato C){
        string query = "INSERT INTO Candidato  (IdPartido, Apellido, Nombre, Foto, Postulacion) VALUES (@ZIdPartido, @ZApellido, @ZNombre, @ZFoto, @ZPostulacion)";
         using (SqlConnection BD = new SqlConnection(_connectionString)){
            BD.Execute(query, new {ZIdPartido = C.IdPartido,ZApellido = C.Apellido, ZNombre = C.Nombre, ZFoto = C.Foto, ZPostulacion = C.Postulacion});
        }
    }

    public static void borrarCandidato(int id){
        string query = "DELETE FROM Candidato WHERE IdCandidato = @Zid";
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            BD.Execute(query, new {@zid = id});
        }
    }

    public static Candidato verCandidato(int id){
        string query = "SELECT * FROM Candidato WHERE IdCandidato = @Zid";
        Candidato C = null;
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
             C = BD.QueryFirstOrDefault(query, new {@zid = id});
        }

        return C;
    }
}