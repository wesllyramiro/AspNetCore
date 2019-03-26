using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Domain;
using Web.Api.Core.Interface;
using System.Text.RegularExpressions;

namespace Web.Api.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _TicketsService;

        public TicketsController(ITicketsService TicketsService)
        {
            _TicketsService = TicketsService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> GetByCondition([FromQuery] string tql)
        {
            try{
                if(string.IsNullOrEmpty(tql)){
                return BadRequest(new { message = "Is Null Or Empty"});
                }else if (Regex.IsMatch(tql.ToUpper(),@"(SELECT|DELETE|COMMIT|BEGIN|DROP)")){
                    return BadRequest(new { message = "Incorrect Query"});
                }
                
                return Ok(_TicketsService.GetByCondition(tql));   
            }catch(Exception e){
                return BadRequest(new {message = e.GetBaseException().Message });
            }
            
        }
    }
}
