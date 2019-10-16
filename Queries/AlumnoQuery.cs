using GraphQL.Types;
using PruebaGraphQL.Models;
using System.Linq;

namespace PruebaGraphQL.Queries{
    public class AlumnoQuery:ObjectGraphType{
        public AlumnoQuery(AlumnoContext cont){
            Field<AlumnoType>("Alumno",
            "Alumno Seleccionado",
            arguments:new QueryArguments(new QueryArgument<IntGraphType>{
                Name="id",
                Description="La id del alumno o alumna que se esta buscando"
            }),
            resolve:context=>{
                int id=context.GetArgument<int>("id");
                Alumno al=cont.alumno.FirstOrDefault(e=>e.Id==id);
                return al;
            });
            
            Field<ListGraphType<AlumnoType>>("Alumnos",
            "Listado de Alumnos",
            resolve:context=>{
                var usuarios=cont.alumno.AsEnumerable().ToList();
                return usuarios;
            }

            );
        }
    }
}