﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ApiReclutamiento.Controllers
{
    public class TimeController : ApiController
    {
        public IHttpActionResult Get(string value)
        {
            string hora;
            string horaFormateada;

            try
            {
                //<Summary>
                //Check the value on the get request, the format for input is HH:MM:SS
                //</Summary>
                if (value != null && Regex.IsMatch(value, "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$"))
                {

                    hora = value;
                    DateTime utc = new DateTime();
                    //Se setean los valores de HH:MM:SS de manera exacta.
                    utc = DateTime.ParseExact(hora, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    //Se transforma el DateTime utc a UTC.
                    horaFormateada = utc.ToUniversalTime().ToString();

                    return Ok(new
                    {
                        code = "00", description = "OK", data = horaFormateada
                    });
                }
                else
                {
                    return BadRequest("400 - bad request.");

                }


            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }



        }
    }
}

