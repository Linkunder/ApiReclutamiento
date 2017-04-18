using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ApiReclutamiento.Controllers
{
    public class WordController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(JObject jsonData)
        {
            //Se obtiene el Json
            dynamic json = jsonData;
            //Se accede al data que contiene la palabra que se debe cambiar a mayus
            try
            {
                if (json.data != null)
                {
                    string palabra = json.data;

                    if (Regex.IsMatch(palabra, "[a-z]{4}"))
                    {
                        return Ok(
                            new
                            {
                               code = 00 , descripton = "OK", data = palabra.ToUpper()
                            }
                                );

                    }
                }
            }catch(Exception e)
            {
                
                return InternalServerError(e);
            }
            return BadRequest("400-Bad Request.");

    

        }


    }
}
