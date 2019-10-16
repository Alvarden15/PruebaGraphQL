using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaGraphQL.Queries;
using PruebaGraphQL.Models;
using GraphQL;
using GraphQL.Types;


namespace PruebaGraphQL.Controllers
{
    [ApiController]
    [Route("graphql")]
    public class AlumnoController : ControllerBase
    {
        
        private readonly AlumnoContext contexto;

        public AlumnoController(AlumnoContext co){
            contexto=co;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQuery query){
            var inputs=query.Variables.ToInputs();
            var schema= new Schema{
                Query=new AlumnoQuery(contexto)
            };
            var result=await new DocumentExecuter().ExecuteAsync(e=>{
                 e.Schema=schema;
                 e.Query=query.Query;
                 e.OperationName=query.OperationName;
                 e.Inputs=inputs;

                }
            );
            if(result.Errors?.Count>0){
                return BadRequest();
            }
            return Ok(result);

        }
       

       
    }
}
