using GraphQL.Types;
using PruebaGraphQL.Models;


namespace PruebaGraphQL.Queries{
    public class AlumnoType:ObjectGraphType<Alumno>{
        public AlumnoType(){
            Name="Alumno";
            Description="El alumno o alumna de la escuela";
            Field(u=>u.Id,type:typeof(IntGraphType)).Description("El id del usuario");
            Field(u=>u.Nombre).Description("El nombre del alumno");
            Field(u=>u.Apellido).Description("El apellido del alumno");
            Field(u=>u.Edad).Description("La edad del alumno");
        }
    }
}