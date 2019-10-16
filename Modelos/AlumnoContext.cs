using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace PruebaGraphQL.Models
{
    public class AlumnoContext: DbContext{

        public AlumnoContext(DbContextOptions<AlumnoContext> options): base(options){

        }

        public DbSet<Alumno> alumno {get; set;}
    }
}